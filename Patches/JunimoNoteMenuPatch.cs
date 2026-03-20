using HarmonyLib;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Menus;

namespace SeasonPlanner.Patches;

[HarmonyPatch(typeof(JunimoNoteMenu), nameof(JunimoNoteMenu.draw), new[] { typeof(SpriteBatch) })]
internal static class JunimoNoteMenuPatch
{
    [HarmonyPriority(Priority.Low)]
    private static void Postfix(JunimoNoteMenu __instance, SpriteBatch b)
    {
        if (!ModEntry.TryGetSharedState(out var missingItems, out var config)) return;
        if (config is null || !config.ShowInventoryTooltips) return;

        var hovered = __instance.hoveredItem as StardewValley.Item;
        if (hovered is null) return;

        TooltipHelper.DrawCommunityTooltip(b, hovered, missingItems, config);
    }
}
