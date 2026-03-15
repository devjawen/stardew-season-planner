using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace SeasonPlanner.Patches;

/// <summary>
/// Envanter ve sandık patch'lerinin ortak kullandığı tooltip çizim yardımcısı.
/// </summary>
internal static class TooltipHelper
{
    // Kategori renkleri
    private static readonly Color ColorCrop         = new(34, 139, 34);   // yeşil
    private static readonly Color ColorFish         = new(30, 100, 200);  // mavi
    private static readonly Color ColorArtisan      = new(160, 60, 160);  // mor
    private static readonly Color ColorConstruction = new(139, 90, 43);   // kahve
    private static readonly Color ColorOther        = new(180, 120, 0);   // turuncu

    internal static Color GetCategoryColor(BundleCategory cat) => cat switch
    {
        BundleCategory.Crop         => ColorCrop,
        BundleCategory.Fish         => ColorFish,
        BundleCategory.Artisan      => ColorArtisan,
        BundleCategory.Construction => ColorConstruction,
        _                           => ColorOther,
    };

    internal static string GetCategoryLabel(BundleCategory cat) =>
        I18n.CategoryLabel(cat);

    /// <summary>
    /// Hover edilen eşyayı eksik bundle listesiyle eşleştirip tooltip çizer.
    /// Tohum ise ekim/büyüme bilgisi de gösterir.
    /// </summary>
    internal static void DrawBundleTooltip(
        SpriteBatch b,
        Item? hovered,
        IReadOnlyList<BundleItem> missing,
        ModConfig config)
    {
        if (!config.ShowInventoryTooltips) return;
        if (hovered is not StardewValley.Object obj) return;

        int itemId = obj.ParentSheetIndex;

        // Tohum mu? Ekim/büyüme bilgisi göster
        bool isSeed = obj.Category == StardewValley.Object.SeedsCategory
                   || BundleScanner.SeedToHarvest.ContainsKey(itemId);

        if (isSeed)
        {
            DrawSeedTooltip(b, itemId);
            return;
        }

        // Normal bundle tooltip
        var matches = missing.Where(bi => bi.ItemId == itemId).ToList();
        if (matches.Count == 0) return;

        var lines  = new List<(string text, Color color)>();
        bool first = true;

        foreach (var match in matches)
        {
            Color headerColor = GetCategoryColor(match.Category);

            if (!first) lines.Add(("─────────────────", new Color(150, 150, 150)));
            first = false;

            lines.Add((I18n.TooltipRequiredFor(match.BundleName), headerColor));

            string qSuffix = match.Quality > 0
                ? I18n.TooltipQualitySuffix(I18n.QualityLabel(match.Quality))
                : string.Empty;
            lines.Add((I18n.TooltipCategoryAmount(GetCategoryLabel(match.Category), match.Quantity) + qSuffix,
                        Game1.textColor));

            if (match.Season is not null)
                lines.Add((I18n.TooltipSeason(I18n.SeasonLabel(match.Season)), Game1.textColor));

            if (match.GrowDays > 0)
            {
                int lastPlant = 28 - match.GrowDays;
                int daysLeft  = lastPlant - Game1.dayOfMonth;
                Color deadlineColor = daysLeft <= 0 ? Color.Red
                                    : daysLeft <= 3 ? new Color(220, 80, 0)
                                    : daysLeft <= 7 ? new Color(200, 160, 0)
                                    : Game1.textColor;
                lines.Add((I18n.TooltipGrowDeadline(match.GrowDays, lastPlant), deadlineColor));
            }

            if (match.RequiresRain)
                lines.Add((I18n.TooltipRainFish(), new Color(80, 140, 220)));

            if (config.ShowShopSource && match.ShopSource is not null)
                lines.Add((I18n.TooltipShopSource(match.ShopSource), new Color(0, 150, 100)));
        }

        DrawBox(b, lines, 0, 0);
    }

    private static void DrawSeedTooltip(SpriteBatch b, int seedId)
    {
        var (growDays, season, harvestId) = BundleScanner.GetCropInfoFromSeed(seedId);
        if (growDays <= 0) return;

        string currentSeason = Game1.currentSeason?.ToLower() ?? "";
        int today            = Game1.dayOfMonth;
        int harvestDay       = today + growDays;
        int lastPlantDay     = 28 - growDays;
        int daysLeft         = lastPlantDay - today;

        bool wrongSeason  = season != null && season != currentSeason;
        bool wontFitMonth = harvestDay > 28;

        var lines = new List<(string text, Color color)>();

        // Başlık
        lines.Add((I18n.SeedTooltipTitle(), new Color(80, 60, 20)));

        // Büyüme süresi
        lines.Add((I18n.SeedTooltipGrowDays(growDays), Game1.textColor));

        // Mevsim
        if (season != null)
            lines.Add((I18n.SeedTooltipSeason(I18n.SeasonLabel(season)), Game1.textColor));

        if (wrongSeason)
        {
            // Yanlış mevsim — ekemezsin
            lines.Add((I18n.SeedTooltipWrongSeason(), Color.Red));
        }
        else
        {
            // Bugün ekersen kaçıncı günde büyür
            if (harvestDay <= 28)
            {
                lines.Add((I18n.SeedTooltipHarvestDay(harvestDay), new Color(34, 139, 34)));
            }
            else
            {
                // Bu ay yetişmez
                lines.Add((I18n.SeedTooltipWontFit(), Color.Red));
            }

            // Son ekim günü
            if (lastPlantDay >= 1)
            {
                Color dlColor = daysLeft <= 0 ? Color.Red
                              : daysLeft <= 3 ? new Color(220, 80, 0)
                              : daysLeft <= 7 ? new Color(200, 160, 0)
                              : Game1.textColor;
                lines.Add((daysLeft <= 0
                    ? I18n.SeedTooltipLastDayPassed()
                    : I18n.SeedTooltipLastPlant(lastPlantDay, daysLeft), dlColor));
            }
        }

        DrawBox(b, lines, 0, 0);
    }

    private static void DrawBox(SpriteBatch b, List<(string text, Color color)> lines, int x, int y)
    {
        const int padding = 12;
        int lineHeight    = (int)Game1.smallFont.MeasureString("A").Y + 6;

        int textWidth = lines.Max(l => (int)Game1.smallFont.MeasureString(l.text).X);
        int width     = textWidth + padding * 2;
        int height    = lines.Count * lineHeight + padding * 2;

        int mx = Game1.getMouseX();
        int my = Game1.getMouseY();
        int sw = Game1.uiViewport.Width;
        int sh = Game1.uiViewport.Height;

        // Farenin üstüne, yatayda fareyle ortalanmış koy.
        // Native tooltip farenin sağına gider → çakışmaz.
        x = mx - width / 2;
        y = my - height - 20;

        // Üstte yer yoksa farenin altına geç
        if (y < 4)
            y = my + 40;

        // Ekran sınırlarına sabitle
        x = Math.Clamp(x, 4, sw - width - 4);
        y = Math.Clamp(y, 4, sh - height - 4);

        IClickableMenu.drawTextureBox(
            b, Game1.menuTexture,
            new Rectangle(0, 256, 60, 60),
            x, y, width, height,
            Color.White, drawShadow: true
        );

        for (int i = 0; i < lines.Count; i++)
        {
            b.DrawString(
                Game1.smallFont,
                lines[i].text,
                new Vector2(x + padding, y + padding + i * lineHeight),
                lines[i].color
            );
        }
    }

}
