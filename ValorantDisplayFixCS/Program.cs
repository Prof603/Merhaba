using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void UpdateKey(List<string> lines, string section, string key, string value)
    {
        int sectionStart = lines.FindIndex(l => l.Trim().Equals($"[{section}]", StringComparison.OrdinalIgnoreCase));
        if (sectionStart == -1)
        {
            lines.Add($"[{section}]");
            lines.Add($"{key}={value}");
            return;
        }

        int nextSection = lines.FindIndex(sectionStart + 1, l => l.Trim().StartsWith("[") && l.Trim().EndsWith("]"));
        if (nextSection == -1) nextSection = lines.Count;

        int keyIndex = lines.FindIndex(sectionStart + 1, nextSection - (sectionStart + 1), l => l.TrimStart().StartsWith(key + "=", StringComparison.OrdinalIgnoreCase));
        if (keyIndex != -1)
        {
            lines[keyIndex] = $"{key}={value}";
        }
        else
        {
            lines.Insert(nextSection, $"{key}={value}");
        }
    }

    static void Main()
    {
        string configDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "AppData", "Local", "VALORANT", "Saved", "Config");

        string? iniPath = Directory.EnumerateFiles(configDir, "GameUserSettings.ini", SearchOption.AllDirectories).FirstOrDefault();
        if (iniPath == null)
        {
            Console.Error.WriteLine("GameUserSettings.ini not found in VALORANT config directory");
            return;
        }

        Console.WriteLine($"Found config: {iniPath}");

        var lines = File.ReadAllLines(iniPath).ToList();
        UpdateKey(lines, "SystemSettings", "ResolutionSizeX", "5120");
        UpdateKey(lines, "SystemSettings", "ResolutionSizeY", "1440");
        UpdateKey(lines, "SystemSettings", "FullscreenMode", "1");
        UpdateKey(lines, "SystemSettings", "LastConfirmedFullscreenMode", "1");

        File.WriteAllLines(iniPath, lines);
        Console.WriteLine("Valorant config updated. Restart the game to apply changes.");
    }
}
