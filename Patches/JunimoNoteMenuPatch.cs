using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using System.Collections.Generic;
using System.Reflection;

namespace SeasonPlanner.Patches;

[HarmonyPatch(typeof(JunimoNoteMenu), nameof(JunimoNoteMenu.draw), new[] { typeof(SpriteBatch) })]
internal static class JunimoNoteMenuPatch
{
    private static FieldInfo? _currentBundleField;
    private static FieldInfo? _ingredientListField;
    private static FieldInfo? _bundleIngredientDescriptionField;
    private static bool _fieldsResolved;

    [HarmonyPriority(Priority.Low)]
    private static void Postfix(JunimoNoteMenu __instance, SpriteBatch b)
    {
        if (!ModEntry.TryGetSharedState(out var missingItems, out var config)) return;
        if (config is null || !config.ShowInventoryTooltips) return;

        Item? hovered = FindHoveredIngredient(__instance);
        if (hovered is null) return;

        TooltipHelper.DrawCommunityTooltip(b, hovered, missingItems, config);
    }

    private static void ResolveFields(JunimoNoteMenu menu)
    {
        if (_fieldsResolved) return;
        _fieldsResolved = true;

        var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

        var menuType = menu.GetType();
        _currentBundleField = menuType.GetField("currentBundle", flags)
                           ?? menuType.GetField("_currentBundle", flags);

        if (_currentBundleField != null)
        {
            var bundleType = _currentBundleField.FieldType;
            _ingredientListField = bundleType.GetField("ingredientList", flags)
                                ?? bundleType.GetField("ingredients", flags)
                                ?? bundleType.GetField("_ingredientList", flags);

            _bundleIngredientDescriptionField = bundleType.GetField("bundleIngredientDescription", flags)
                                             ?? bundleType.GetField("ingredientDescription", flags);
        }

        ModEntry.Instance?.Monitor.Log(
            $"[JunimoNoteMenuPatch] currentBundle={_currentBundleField?.Name ?? "null"}, " +
            $"ingredientList={_ingredientListField?.Name ?? "null"}",
            StardewModdingAPI.LogLevel.Debug);
    }

    private static Item? FindHoveredIngredient(JunimoNoteMenu menu)
    {
        int mx = Game1.getMouseX();
        int my = Game1.getMouseY();

        ResolveFields(menu);

        if (_currentBundleField != null && _ingredientListField != null)
        {
            var bundle = _currentBundleField.GetValue(menu);
            if (bundle != null)
            {
                var list = _ingredientListField.GetValue(bundle) as IList<ClickableTextureComponent>;
                if (list != null)
                {
                    foreach (var component in list)
                    {
                        if (!component.bounds.Contains(mx, my)) continue;
                        var item = TryCreateItem(component.name ?? string.Empty);
                        if (item != null) return item;
                    }
                }
            }
        }

        var allFields = menu.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in allFields)
        {
            if (field.GetValue(menu) is not IList<ClickableTextureComponent> list) continue;
            foreach (var component in list)
            {
                if (!component.bounds.Contains(mx, my)) continue;
                var item = TryCreateItem(component.name ?? string.Empty);
                if (item != null) return item;
            }
        }

        return null;
    }

    private static Item? TryCreateItem(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        string itemId = name.Contains(' ') ? name.Split(' ')[0] : name;
        if (string.IsNullOrWhiteSpace(itemId)) return null;

        if (itemId.StartsWith("(", System.StringComparison.Ordinal))
        {
            try
            {
                var item = ItemRegistry.Create(itemId, 1, 0, allowNull: true);
                if (item != null) return item;
            }
            catch { }
        }

        foreach (string prefix in new[] { "(O)", "(F)", "(BC)", "(W)", "(H)", "(S)" })
        {
            try
            {
                var item = ItemRegistry.Create($"{prefix}{itemId}", 1, 0, allowNull: true);
                if (item != null) return item;
            }
            catch { }
        }

        try
        {
            var data = ItemRegistry.GetData(itemId);
            if (data != null)
                return ItemRegistry.Create(data.QualifiedItemId, 1, 0, allowNull: true);
        }
        catch { }

        if (int.TryParse(itemId, out int legacyId) && legacyId > 0)
        {
            try { return new StardewValley.Object(itemId, 1); }
            catch { }
        }

        return null;
    }
}
