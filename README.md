<div align="center">

# 🌱 Season Planner & Bundle Reminder

**A SMAPI mod for Stardew Valley that tracks your Community Center bundle progress,  
marks last planting deadlines on your calendar, and sends smart HUD alerts — so you never miss a season again.**

<br/>

[![SMAPI](https://img.shields.io/badge/SMAPI-4.1%2B-2b8a3e?style=for-the-badge&logo=data:image/png;base64,)](https://smapi.io)
[![Stardew Valley](https://img.shields.io/badge/Stardew%20Valley-1.6%2B-c0692e?style=for-the-badge)](https://www.stardewvalley.net/)
[![License: CC BY-NC-ND 4.0](https://img.shields.io/badge/License-CC%20BY--NC--ND%204.0-lightgrey?style=for-the-badge)](LICENSE)
[![Version](https://img.shields.io/badge/Version-1.0.0-blueviolet?style=for-the-badge)](manifest.json)
[![Language](https://img.shields.io/badge/Languages-EN%20%7C%20TR-informational?style=for-the-badge)](#-multi-language)
[![GitHub](https://img.shields.io/badge/GitHub-Repository-black?style=for-the-badge&logo=github)](https://github.com/devjawen/stardew-season-planner)
[![NexusMods](https://img.shields.io/badge/Nexus%20Mods-Download-yellow?style=for-the-badge&logo=firefox)](https://www.nexusmods.com/stardewvalley/mods/43803)

<br/>

### 🔗 Quick Links

<div>
  <a href="https://github.com/devjawen/stardew-season-planner/releases">📥 <strong>Download (GitHub)</strong></a>
  &nbsp;&nbsp;•&nbsp;&nbsp;
  <a href="https://www.nexusmods.com/stardewvalley/mods/43803">📥 <strong>Download (Nexus Mods)</strong></a>
  &nbsp;&nbsp;•&nbsp;&nbsp;
  <a href="https://github.com/devjawen/stardew-season-planner/issues">⚠️ <strong>Report Bug</strong></a>
  &nbsp;&nbsp;•&nbsp;&nbsp;
  <a href="https://github.com/devjawen/stardew-season-planner/discussions">💬 <strong>Discussions</strong></a>
</div>

<br/>

<table>
  <tr>
    <td align="center">🇺🇸&nbsp; <strong>English</strong> — you're here</td>
    <td align="center"><a href="#-türkçe">🇹🇷&nbsp; <strong>Türkçe</strong> — aşağıda ↓</a></td>
  </tr>
</table>

</div>

---

## ✨ Key Features

<table>
<tr>
<td>

### 📋 **Bundle Panel**
Lists every missing item grouped by category. Open with `F5` (configurable) and plan your collection strategy.

### 📅 **Calendar Markers**  
Automatically marks last planting days on the in-game calendar with visual indicators.

### 🔔 **Smart Notifications**
Morning HUD alerts for planting deadlines, rain-fish opportunities, and seasonal reminders.

</td>
<td>

### 🎯 **Tooltips & Info**
- **Inventory Hover**: See which bundle an item belongs to
- **Chest Hover**: Same bundle info for stored items
- **Shop Source**: Know where to buy any item

### 📌 **Planning Tools**
- Mark items as "planned" to filter priorities
- Sort by urgency or name
- Pan individual items in the checklist

### 💾 **Persistent State**
Remembers your panel position and preferences between sessions.

</td>
</tr>
</table>

---

## 📸 Screenshots

| Bundle Panel | Calendar Markers | Planning Tools |
|---|---|---|
| View all missing items in organized tabs with real-time filtering | Visual deadline markers on your in-game calendar | Mark and sort items by priority and urgency |

---

## 🛠️ Installation

### 📋 Requirements

| Requirement | Minimum | Notes |
|---|---|---|
| **Stardew Valley** | `1.6+` | Available on all platforms |
| **SMAPI** | `4.1+` | [Download SMAPI](https://smapi.io) |
| **Generic Mod Config Menu** | — | _(Optional)_ For in-game settings UI |

---

### 📥 Installation Steps

#### **Option A: Download from NexusMods** ⭐ (Recommended)
1. Visit [Season Planner on NexusMods](https://www.nexusmods.com/stardewvalley/mods/43803)
2. Click **"Files"** → **"Download"** on the main file
3. Extract to your `Stardew Valley/Mods/` folder
4. Launch the game through SMAPI

#### **Option B: Download from GitHub Releases**
1. Go to [Releases Page](https://github.com/devjawen/stardew-season-planner/releases)
2. Download the latest `SeasonPlanner.zip`
3. Extract to your `Stardew Valley/Mods/` folder
4. Launch the game through SMAPI

#### **Final Folder Structure**
```
Stardew Valley/
└── Mods/
    └── SeasonPlanner/
        ├── SeasonPlanner.dll
        ├── manifest.json
        ├── config.json (auto-created on first run)
        └── i18n/
            ├── default.json
            └── tr.json
```

---

## ⚙️ Configuration & Settings

All settings can be changed **in-game** via **Generic Mod Config Menu** (GMCM) interface, or by manually editing `config.json`.

> 💡 **Tip**: Install [Generic Mod Config Menu](https://www.nexusmods.com/stardewvalley/mods/5098) for the best config experience!

### Default Settings

| Setting | Default | Description |
|---|---|---|
| `ShowCalendarMarkers` | ✅ | Display deadline markers on the calendar |
| `ShowHudNotifications` | ✅ | Show morning HUD alerts for urgent deadlines |
| `ShowInventoryTooltips` | ✅ | Show bundle info when hovering inventory items |
| `ShowChestTooltips` | ✅ | Show bundle info when hovering chest items |
| `FilterConstructionItems` | ✅ | Hide construction materials (Wood/Stone/etc.) from list |
| `ShowShopSource` | ✅ | Display shop locations for purchasable items |
| `CalendarWarningDaysLeft` | `7` | Days before deadline to show warnings |
| `PanelHotkey` | `F5` | Keyboard shortcut to toggle bundle panel |
| `RememberPanelPosition` | ✅ | Save panel position between sessions |

---

## 🎮 Controls & Hotkeys

| Input | Action |
|---|---|
| <kbd>F5</kbd> | Open / close the Missing Bundle Panel _(default)_ |
| <kbd>ESC</kbd> | Close the currently open panel |
| <kbd>Scroll</kbd> / <kbd>Arrow Keys</kbd> | Navigate through the item list |
| <kbd>Click "Plan"</kbd> | Mark an item as planned (toggles) |
| <kbd>Click Sort Button</kbd> | Switch between sorting by urgency or name |

> ⚙️ The panel hotkey can be customized in GMCM or `config.json`.

---

## 📋 Bundle Panel Interface

### Panel Tabs
The panel organizes missing items for easy browsing:

| Tab | Contents | Icon |
|---|---|---|
| **All** | Every remaining item | 📦 |
| **Crop** | Crops and forageables | 🌾 |
| **Fish** | Fish species (with season/rain info) | 🐟 |
| **Artisan** | Artisan goods and crafted items | 🎨 |
| **Forage** | Foraged items by season | 🍃 |
| **Build** | Construction materials | 🔨 |
| **Other** | Miscellaneous items | 📌 |

### Sorting Options
- **Urgency Sort** (🔴 Red): Shows most urgent deadlines first
- **Name Sort** (📝): Alphabetical ordering

### Color Indicators
- 🔴 **Red**: Urgent (deadline today or tomorrow)
- 🟡 **Yellow**: Soon (deadline within the warning period)
- ⚪ **Gray**: Later (plenty of time remaining)

---

## 🌍 Multi-language

The mod ships with full localizations for:

| Language | File | Status |
|---|---|---|
| English | `i18n/default.json` | ✅ Complete |
| Türkçe | `i18n/tr.json` | ✅ Complete |
| _Your language?_ | `i18n/xx.json` | 🚀 Help us! |

👉 See [Contributing](#contributing) to add a new language!

---

## 👩‍💻 Building from Source

Want to build the mod locally or contribute? Here's how:

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Git
- Your Stardew Valley installation folder path

### Setup & Build

1. **Clone the repository:**
   ```bash
   git clone https://github.com/devjawen/stardew-season-planner.git
   cd stardew-season-planner
   ```

2. **Configure your local game path:**
   ```bash
   # Copy the example configuration
   cp Directory.Build.props.example Directory.Build.props
   ```

3. **Edit `Directory.Build.props`** and set `<GamePath>` to your Stardew Valley folder:
   ```xml
   <GamePath>C:\Program Files (x86)\Steam\steamapps\common\Stardew Valley</GamePath>
   ```
   > On macOS: `/Applications/Stardew Valley/Contents/Resources`  
   > On Linux: `~/.steam/steam/steamapps/common/Stardew Valley`

4. **Build the project:**
   ```bash
   dotnet build
   ```

5. **Output location:**
   - Release build: `bin/Release/net6.0/`
   - Debug build: `bin/Debug/net6.0/`

---

## 🤝 Contributing

We welcome contributions from the community! Whether it's bug reports, feature requests, or code improvements, your input helps make Season Planner better for everyone.

### 🐛 Report a Bug

<details>
<summary><strong>Click to expand</strong></summary>

1. Go to [GitHub Issues](https://github.com/devjawen/stardew-season-planner/issues)
2. Click **"New Issue"** → **"Bug Report"**
3. Include:
   - Your **Stardew Valley version** (check main menu)
   - Your **SMAPI version** (in SMAPI console)
   - A list of **other mods installed**
   - **Steps to reproduce** the bug
   - **Expected vs. actual behavior**
   - _(Optional)_ SMAPI log file (found in `StardewValley/` folder)

</details>

### ✨ Suggest a Feature

<details>
<summary><strong>Click to expand</strong></summary>

1. Go to [GitHub Discussions](https://github.com/devjawen/stardew-season-planner/discussions)
2. Create a new discussion under **"Ideas"** 
3. Describe your feature idea and why it would be useful
4. Community feedback will help shape the direction!

</details>

### 💻 Contribute Code

<details>
<summary><strong>Click to expand</strong></summary>

1. **Fork** the repository
2. **Create** a feature branch: `git checkout -b feature/your-feature-name`
3. **Commit** your changes: `git commit -m "Add: detailed description of changes"`
4. **Push** to your fork: `git push origin feature/your-feature-name`
5. **Open a Pull Request** with a clear description

**Code Guidelines:**
- Follow the existing C# code style and conventions
- Add/update translations in `i18n/` for any new user-facing strings
- Keep PRs focused on **one feature or fix** per PR
- Include comments for complex logic
- Test thoroughly before submitting

</details>

### 🌍 Add/Improve Translations

Help us support more languages!

<details>
<summary><strong>Currently supported languages</strong></summary>

| Language | File | Status |
|---|---|---|
| English | `i18n/default.json` | ✅ Complete |
| Türkçe | `i18n/tr.json` | ✅ Complete |
| _Your language?_ | `i18n/xx.json` | 🚀 Help us! |

</details>

To add a translation:
1. Copy `i18n/default.json` to `i18n/xx.json` (replace `xx` with language code)
2. Translate all strings
3. Submit a PR with your translation file

---

## 📄 License & Attribution

This project is licensed under **[CC BY-NC-ND 4.0](LICENSE)** — a Creative Commons license with specific terms.

### ✅ You May:
- ✅ Download, use, and enjoy the mod
- ✅ Share it with friends (with proper attribution)
- ✅ Create content (videos, guides) featuring the mod

### ❌ You May Not:
- ❌ Use it for commercial purposes
- ❌ Publish modified versions or forks
- ❌ Claim ownership or remove attribution

**© 2024 Jawen** — All rights reserved under CC BY-NC-ND 4.0

> 📝 This license protects the original creator's work while allowing community enjoyment.

---

## 🔐 Security

Found a security vulnerability? Please report it responsibly.

📧 See [SECURITY.md](SECURITY.md) for detailed reporting guidelines.

---

## 📞 Support

### Getting Help
- **Bug Report?** → [GitHub Issues](https://github.com/devjawen/stardew-season-planner/issues)
- **Feature Idea?** → [GitHub Discussions](https://github.com/devjawen/stardew-season-planner/discussions)
- **General Questions?** → [GitHub Discussions - Q&A](https://github.com/devjawen/stardew-season-planner/discussions/categories/q-a)

### Links
- 🌐 [GitHub Repository](https://github.com/devjawen/stardew-season-planner)
- 🔗 [NexusMods Page](https://www.nexusmods.com/stardewvalley/mods/43803)
- 🎮 [Stardew Valley Official](https://www.stardewvalley.net/)
- 🔌 [SMAPI Official](https://smapi.io)

---

<div align="center">

**Made with ☕ and too many in-game seasons**

<br/>

Created by [**Jawen**](https://github.com/devjawen) | [Support the project](https://github.com/devjawen/stardew-season-planner) ⭐

</div>
<details>
<summary><strong>🇹🇷 Türkçe Açıklama (tıklayın)</strong></summary>

<br/>

# 🌱 Stardew Season Planner — Türkçe Rehberi

**Season Planner & Bundle Reminder**, Stardew Valley'deki Topluluk Merkezi paket ilerlemenizi takip eden, takvimde son ekim günlerini işaretleyen ve akıllı HUD bildirimleri gönderen bir SMAPI modudur.

---

## ⚡ Hızlı Başlangıç

- 📥 **Download**: [GitHub](https://github.com/devjawen/stardew-season-planner/releases) | [Nexus Mods](https://www.nexusmods.com/stardewvalley/mods/43803)
- 🎮 **Oyun İçi Kontrol**: `F5` ile paneli aç/kapat
- ⚙️ **Ayarlar**: Generic Mod Config Menu (GMCM) üzerinden değiştir

---

## 📋 Özellikler

| Özellik | Açıklama |
|---|---|
| 📋 **Paket Paneli** | Eksik eşyaları kategoriye göre gruplandırır. `F5` ile açılır. |
| 📅 **Takvim İşaretleri** | Son ekim günleri oyun takviminde otomatik işaretlenir. |
| 🔔 **HUD Uyarıları** | Sabah uyandığınızda ekim son günleri ve yağmur balığı fırsatları için uyarı görüntüler. |
| 🧳 **Envanter Tooltip** | Çantanızdaki eşyanın hangi pakete ait olduğunu gösterir. |
| 📦 **Sandık Tooltip** | Sandıklardaki eşyalar için de aynı bilgiyi gösterir. |
| 🛒 **Mağaza Bilgisi** | Satın alınabilecek eşyaların nereden alınacağını gösterir. |
| 📌 **Planlama Aracı** | Eşyaları "plan yap" olarak işaretleyerek öncelikleri belirleyin. |
| 💾 **Panel Konumu** | Paneli taşıdığınızda, konum oturumlar arası hatırlanır. |

---

## 🛠️ Kurulum

### 📋 Gereksinimler

| Gereksinim | Minimum | Notlar |
|---|---|---|
| **Stardew Valley** | `1.6+` | Tüm platformlarda mevcut |
| **SMAPI** | `4.1+` | [SMAPI İndir](https://smapi.io) |
| **Generic Mod Config Menu** | — | _(İsteğe Bağlı)_ Oyun içi ayarlar menüsü için |

### 📥 Kurulum Adımları

#### **Seçenek A: NexusMods'tan İndir** ⭐ (Önerilen)
1. [Season Planner - NexusMods](https://www.nexusmods.com/stardewvalley/mods/43803) sayfasını ziyaret edin
2. **"Files"** → **"Download"** butonuna tıklayın
3. `Stardew Valley/Mods/` klasörüne çıkarın
4. Oyunu SMAPI ile başlatın

#### **Seçenek B: GitHub'tan İndir**
1. [Sürümler Sayfası](https://github.com/devjawen/stardew-season-planner/releases) ziyaret edin
2. En yeni `SeasonPlanner.zip` dosyasını indirin
3. `Stardew Valley/Mods/` klasörüne çıkarın
4. Oyunu SMAPI ile başlatın

---

## ⚙️ Ayarlar

Tüm ayarlar **Generic Mod Config Menu** üzerinden oyun içinde değiştirilebilir veya `config.json` dosyasını düzenleyebilirsiniz.

| Ayar | Varsayılan | Açıklama |
|---|---|---|
| Takvim İşaretleri | ✅ | Takvimde ekim son günlerini göster |
| HUD Uyarıları | ✅ | Sabah acil uyarılarını göster |
| Envanter Tooltip | ✅ | Çantadaki eşyalar için paket bilgisi göster |
| Sandık Tooltip | ✅ | Sandıklardaki eşyalar için paket bilgisi göster |
| İnşaat Öğelerini Gizle | ✅ | Listeden Odun/Taş/vb. kaldır |
| Mağaza Kaynağı | ✅ | Satın alınabilen eşyaların kaynağını göster |
| Uyarı Eşiği (Gün) | `7` | Son güne kaç gün kala uyarı başlasın |
| Panel Kısayolu | `F5` | Paneli açma/kapama tuşu |

---

## 🎮 Kontroller

| Tuş | İşlem |
|---|---|
| <kbd>F5</kbd> | Paneli aç/kapat _(varsayılan)_ |
| <kbd>ESC</kbd> | Paneli kapat |
| <kbd>Scroll</kbd> | Eşya listesinde gezin |
| **Plan Düğmesi** | Eşyayı planla olarak işaretle |

---

## 🤝 Katkıda Bulunma

### 🐛 Hata Bildir
[GitHub Issues](https://github.com/devjawen/stardew-season-planner/issues) sayfasında hata raporu açabilirsiniz.

Lütfen şunları ekleyin:
- Stardew Valley sürümü
- SMAPI sürümü
- Yüklü diğer modlar
- Hatayı tekrar oluşturma adımları

### ✨ Öneride Bulunun
[GitHub Discussions](https://github.com/devjawen/stardew-season-planner/discussions) sayfasında fikirlerinizi paylaşabilirsiniz.

### 💻 Kod Katkısı
1. Repo'yı fork edin
2. Yeni bir branch oluşturun: `git checkout -b feature/ozellik-adi`
3. Değişiklikleri commit edin: `git commit -m "description"`
4. Fork'unuza push edin: `git push origin feature/ozellik-adi`
5. Pull Request açın

---

## 📄 Lisans

**CC BY-NC-ND 4.0** — Atıf ile kullanabilir ve paylaşabilirsiniz; ticari kullanım ve değiştirilmiş sürüm yayınlamak yasaktır.

---

## 📞 Destek

- 🐛 **Hata Raporu**: [GitHub Issues](https://github.com/devjawen/stardew-season-planner/issues)
- 💬 **Soru/Öneriler**: [GitHub Discussions](https://github.com/devjawen/stardew-season-planner/discussions)
- 🌐 **GitHub**: [Depo](https://github.com/devjawen/stardew-season-planner)
- 🔗 **NexusMods**: [Sayfa](https://www.nexusmods.com/stardewvalley/mods/43803)

</details>

---

<div align="center">
  <sub>Made with ☕ and too many in-game seasons by <a href="https://github.com/devjawen">Jawen</a></sub>
</div>
