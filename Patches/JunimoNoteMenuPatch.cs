using HarmonyLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using System.Reflection;

namespace SeasonPlanner.Patches;

[HarmonyPatch(typeof(JunimoNoteMenu), nameof(JunimoNoteMenu.draw), new[] { typeof(SpriteBatch) })]
internal static class JunimoNoteMenuPatch
{
    private static readonly FieldInfo? IngredientListField =
        typeof(JunimoNoteMenu).GetField("ingredientList", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

    [HarmonyPriority(Priority.Low)]
    private static void Postfix(JunimoNoteMenu __instance, SpriteBatch b)
    {
        if (!ModEntry.TryGetSharedState(out var missingItems, out var config)) return;
        if (config is null || !config.ShowInventoryTooltips) return;

        Item? hovered = FindHoveredIngredient(__instance);
        if (hovered is null) return;

        TooltipHelper.DrawCommunityTooltip(b, hovered, missingItems, config);
    }

    private static Item? FindHoveredIngredient(JunimoNoteMenu menu)
    {
        int mx = Game1.getMouseX();
        int my = Game1.getMouseY();

        var ingredientList = IngredientListField?.GetValue(menu) as System.Collections.Generic.List<ClickableTextureComponent>;
        if (ingredientList is null) return null;

        foreach (var component in ingredientList)
        {
            if (!component.bounds.Contains(mx, my)) continue;

            string name = component.name ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name)) continue;

            string itemId = name.Contains(' ') ? name.Split(' ')[0] : name;

            try
            {
                string qualifiedId = itemId.StartsWith("(", System.StringComparison.Ordinal)
                    ? itemId
                    : $"(O){itemId}";

                var item = ItemRegistry.Create(qualifiedId, 1, 0, allowNull: true);
                if (item is not null) return item;
            }
            catch { }

            if (int.TryParse(itemId, out int legacyId) && legacyId > 0)
            {
                try
                {
                    return new StardewValley.Object(itemId, 1);
                }
                catch { }
            }
        }

        return null;
    }
}
