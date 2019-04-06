using Cirilla.Core.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorldEventDataEditor
{
    class Utility
    {
        // From https://github.com/fholger/RocksmithToTab
        public static string GetGameInstallDir()
        {
            string InstallDir = "";

            // Get Steam install dir
            RegistryKey steamKey = Registry.LocalMachine.OpenSubKey("Software\\Valve\\Steam") ?? Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Valve\\Steam");
            string SteamFolder = steamKey.GetValue("InstallPath").ToString();

            // Get Steam libraries
            List<string> folders = new List<string>();
            try
            {
                string steamFolder = SteamFolder;
                folders.Add(steamFolder);

                // the list of additional steam libraries can be found in the config.vdf file
                string configFile = Path.Combine(steamFolder, "config", "config.vdf");
                Regex regex = new Regex("BaseInstallFolder[^\"]*\"\\s*\"([^\"]*)\"");
                using (StreamReader reader = new StreamReader(configFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Match match = regex.Match(line);
                        if (match.Success)
                        {
                            folders.Add(Regex.Unescape(match.Groups[1].Value));
                        }
                    }
                }
            }
            catch (Exception)
            {
                // if there's any error in getting the Steam directory, ignore it for now.
            }

            var appFolders = folders.Select(x => x + "\\SteamApps\\common");
            foreach (var folder in appFolders)
            {
                try
                {
                    var matches = Directory.GetDirectories(folder, "Monster Hunter World");
                    if (matches.Length >= 1)
                    {
                        InstallDir = matches[0];
                    }
                }
                catch (DirectoryNotFoundException)
                {
                    InstallDir = folders[0];
                }

            }

            return InstallDir;
        }

        // Add line to log
        public static void Log(string Message, Form1 Form)
        {
            Form.TextBoxLog.AppendText($"{Message}\r\n");
        }

        // Get quest title
        public static string GetQuestTitle(string InputFile)
        {
            GMD Gmd = new GMD(InputFile);
            var GmdEntries = Gmd.Entries.OfType<GMD_Entry>();
            string QuestTitle = GmdEntries.ElementAt(0).Value;
            return QuestTitle;
        }
    }
}
