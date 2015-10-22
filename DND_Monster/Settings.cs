﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DND_Monster
{
    public static class Settings
    {
        public static string SettingsFile = "DND_monster.ini";

        public static void Load()
        {
            List<string> Args = new List<string>();

            try
            {
                if (File.Exists(SettingsFile))
                {
                    Args = File.ReadAllLines(SettingsFile).ToList<string>();
                }
                else
                {
                    return;
                }

                foreach (string arg in Args)
                {
                    if (arg.Contains("Last Directory="))
                    {
                        Help.LastDirectory = arg.Split('=')[1];
                    }
                }
            }
            catch { }
        }

        public static void Save()
        {
            try
            {
                File.WriteAllLines(SettingsFile, new List<string>()
                {
                    "Last Directory=" + Help.LastDirectory
                });
            }
            catch { }
        }
    }
}
