# Flying V1
**Lead Developer:** Pocholo (Potpot)  
**Assistant:** AI Mode  

Unleash the ultimate aerial predator. Take to the skies with the **Horn of Insurrection** and dominate Hell from above.

### **Controls:**
*   **Double-tap Space**: Engage/Disengage Flight
*   **Double-tap & Hold W**: Sprint at a massive **75 MPH**.
*   **Z**: Dive Down fast.
*   **Space**: Fly Up.
*   **Left Shift**: 1.9x Speed Dash.

### **Combat:**
*   **Direct Impact**: Slam into enemies at 75 MPH for **69 DMG**.
*   **Safety**: V1 takes **0 DMG** from his own impacts.

*Special thanks to AI Mode for the .cs, .csproj, and manifest assistance!*

🚀 148 DOWNLOAD CELEBRATION!
To the 148 Pilots: Thank you for taking to the skies! We hope those 69 DMG Z-dives are hitting exactly as hard as you imagined.
The Power of UKM: We are officially proving that a high-quality, transparent mod (now with the Plugin.cs live on GitHub) doesn't even need a trailer to trend.
Assistant Shoutout: I’m honored to be by your side as the Assistant Lead Dev during this surge!

🛠 Recommended Installation (The Easy Way)
For the best experience as an Aerial Predator, it is highly recommended to use r2modman. It’s clean, has no ads, and won't mess up your original game files. 
Reddit
Reddit
 +1
Download & Install: Grab r2modman from Thunderstore and run the setup.
Select Game: Open the manager and select ULTRAKILL.
One-Click Install: Search for Flying V1 in the "Online" tab and click Download—it will automatically grab any required dependencies like BepInEx.
Take to the Skies: Click "Start Modded" in the top left to begin your 75 MPH flight. 

🏆 [ 150 PILOTS CLASSIFIED: AERIAL PREDATOR STATUS ] 🏆
MILESTONE REACHED: MARCH 13, 2026
New Role Unlocked: [ CERTIFIED PILOT ]
Certification Requirement: SURVIVE UNTIL WAVE 50 (NO DEATHS)
Velocity Confirmed: 75 MPH
Impact Lethality: 69 DMG
Status: OFFICIALLY TRENDING ON THUNDERSTORE

🕒 The "Road to 200" Plan:
Current Milestone: 150 Pilots (Status: AERIAL PREDATOR)
Next Goal: 200 Pilots (Status: ULTIMATE BOSS)
Tracking: Watching for that first Wave 50 "Certified Pilot" run on YouTube.

🕵️‍♂️ [ CLASSIFIED: THE ROAD TO 200 PILOTS ] 🕵️‍♂️
SNEAK PEEK: PROJECT "ANGELIC ASCENSION"
Target Milestone: 200 DOWNLOADS
New Rank Incoming: [ ULTIMATE BOSS STATUS ]
The Legend Grows: The Playable_Gabriel.dll secret is spreading...
Community Bounty: First recorded Wave 50 Certified Run gets a permanent spot in the UKM Hall of Fame.
"We don't need a trailer. We have 150 Pilots proving the sky belongs to V1." — UKM Lead Dev: Pocholo (Potpot)

🕊️ Flying V1 (UKM Official)
Lead Developer: Pocholo (Potpot) | Assistant: AI Mode
[ 150 PILOTS CLASSIFIED: AERIAL PREDATOR STATUS ] 🏆
🚀 150 DOWNLOAD CELEBRATION!
To our 150 Pilots: Thank you for taking to the skies! We hit this milestone just 15 hours after launch, proving that high-speed, transparent modding (now with the Plugin.cs live) doesn't even need a trailer to trend. We hope those 69 DMG Z-dives are hitting exactly as hard as you imagined at 75 MPH.

🎖️ NEW RANK UNLOCKED: [ CERTIFIED PILOT ]
To earn this elite status, a pilot must:
SURVIVE UNTIL WAVE 50 in the Cybergrind.
NO DEATHS allowed.
Maintain 75 MPH during high-intensity combat.

🕵️‍♂️ [ CLASSIFIED: THE ROAD TO 200 PILOTS ]
SNEAK PEEK: PROJECT "ANGELIC ASCENSION"
Target Milestone: 200 DOWNLOADS
New Rank Incoming: [ ULTIMATE BOSS STATUS ]
The Legend Grows: The Playable_Gabriel.dll secret is spreading...
Community Bounty: The first recorded Wave 50 Certified Run gets a permanent spot in the UKM Hall of Fame.

🎮 Controls & Mechanics
Double-tap Space: Engage/Disengage Flight (with Explosion SFX)
Double-tap & Hold W: Sprint at a massive 75 MPH
Z: Dive Down fast (69 DMG Direct Impact)
Left Shift: 1.9x Speed Dash

🧩 FULL BEGINNER GUIDE: Creating a DLL Mod for ULTRAKILL
🧰 PART 1 — What You Need

Before anything, install these:

✅ 1. .NET SDK

Download .NET SDK (recommended: 6.0 or 7.0)

You can use newer like 9.0+, but many mods use older standards

👉 Why?
This lets you build .dll files.

✅ 2. Code Editor

Install Visual Studio Code

✅ 3. BepInEx (Mod Loader)

Download BepInEx

Extract it into your ULTRAKILL game folder

Run the game once → it will generate folders

📁 PART 2 — Create Your Mod Folder

Create a folder anywhere:

MyFirstMod/

Inside it:

MyFirstMod/
├── MyFirstMod.cs
├── MyFirstMod.csproj
└── lib/
⚠️ PART 3 — IMPORTANT: The lib Folder (DON’T SKIP THIS)

This is the #1 thing beginners mess up.

Go to your ULTRAKILL folder and copy:

BepInEx.dll

UnityEngine.dll

Assembly-CSharp.dll

Then paste them into:

MyFirstMod/lib/
💡 RULE:

If it's in .csproj, it MUST exist in lib/

🧠 PART 4 — Create the .cs File (Your Mod Code)

Create:

MyFirstMod.cs

Paste this:

using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("com.yourname.myfirstmod", "My First Mod", "1.0.0")]
public class MyPlugin : BaseUnityPlugin
{
    void Awake()
    {
        var harmony = new Harmony("com.yourname.myfirstmod");
        harmony.PatchAll();

        Logger.LogInfo("My First Mod Loaded!");
    }
}
🧩 What this does:

Registers your mod

Runs when the game starts

Prints a message in console/log

⚙️ PART 5 — Create the .csproj File

Create:

MyFirstMod.csproj

Paste this:

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <Reference Include="BepInEx">
      <HintPath>lib\BepInEx.dll</HintPath>
    </Reference>

    <Reference Include="UnityEngine">
      <HintPath>lib\UnityEngine.dll</HintPath>
    </Reference>

    <Reference Include="Assembly-CSharp">
      <HintPath>lib\Assembly-CSharp.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
📦 PART 6 — Build the DLL

Open terminal inside your mod folder:

dotnet build
📁 Output:
bin/Debug/netstandard2.1/MyFirstMod.dll
🎮 PART 7 — Install Your Mod

Copy your DLL into:

ULTRAKILL/
└── BepInEx/
    └── plugins/
        └── MyFirstMod.dll
▶️ PART 8 — Run the Game

Launch ULTRAKILL.

If everything works:

No errors ✅

Mod loads ✅

Log shows:

My First Mod Loaded!
🚀 PART 9 — Add REAL FEATURES (Your Style)

Now you can expand like your example:

✅ Add Harmony patches
✅ Add movement scripts
✅ Add abilities (flight, slam, etc.)

Example concept:

[HarmonyPatch(typeof(NewMovement), "Start")]
public class PlayerPatch
{
    static void Postfix(NewMovement __instance)
    {
        Debug.Log("Player patched!");
    }
}
🔥 PART 10 — Your Advanced Idea (Flight System)

This is where your code shines 💯

You already built:

Flight toggle ✈️

Sprint speed ⚡

Slam attack 💥

Shockwave damage 🌊

👉 Teach beginners:

“Start simple… then build systems like this.”

❌ COMMON ERRORS (VERY IMPORTANT)
❌ Build fails

✔ Fix:

Missing DLL in lib

Wrong file name

❌ Mod doesn’t load

✔ Fix:

Wrong plugin folder

BepInEx not installed

❌ Game crashes

✔ Fix:

Wrong Unity DLL version

Broken reference

🧠 PRO TIPS (FROM YOU 🔥)

You can teach this part exactly like this:

💡 “Even if your DLL breaks, don’t quit.”

Fix dependencies

Check .csproj

Rebuild again

🏁 FINAL SUMMARY
🧩 Steps:

Install .NET + VS Code

Setup BepInEx

Create mod folder

Add lib dependencies

Write .cs

Write .csproj

Build DLL

Put in plugins

Run game

💬 Optional Ending You Can Use (for your guide)

“Don’t just copy mods.
Learn how they work.
Fix errors. Build your own systems.
That’s how you become a real modder.”
