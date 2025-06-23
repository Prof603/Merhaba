# Valorant Display Fix

This repository contains scripts to update the `GameUserSettings.ini` file used by Valorant on Windows. The scripts set the resolution and fullscreen mode for wide monitors (e.g., 5120x1440). A Python version and a C# version are provided.

## Usage

1. Locate your Valorant configuration directory. This is usually under:

```
C:\Users\<YourUsername>\AppData\Local\VALORANT\Saved\Config
```

2. Run the script with Python 3 on Windows:

```
python valorant_display_fix.py
```

The script searches for `GameUserSettings.ini`, updates the resolution to **5120x1440** and sets the fullscreen mode to borderless windowed. Restart the game after running the script to see the effect.

You can modify the `ResolutionSizeX` and `ResolutionSizeY` values in the script if your monitor uses a different resolution.

## C# Version

If you prefer using C#, a .NET console application is available in the `ValorantDisplayFixCS` directory. Ensure that the .NET SDK (version 8.0 or later) is installed and run:

```
dotnet run --project ValorantDisplayFixCS
```

The C# program performs the same updates to `GameUserSettings.ini` as the Python script.
