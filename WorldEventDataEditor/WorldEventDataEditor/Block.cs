using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WorldEventDataEditor
{
    class Block
    {
        // Process Time Table block (00)
        public static void ProcessBlock00(Form1 Form)
        {
            string InputFile = $"{Environment.CurrentDirectory}\\Blocks\\Block_00.bin";
            using (BinaryReader Reader = new BinaryReader(File.Open(InputFile, FileMode.Open)))
            {
                int EntryCount = Reader.ReadInt32(); Utility.Log($"Block 00 Entry Count: {EntryCount}", Form);
                for (int i = 0, QuestID; i < EntryCount; i++)
                {
                    QuestID = Reader.ReadInt32();
                    Reader.BaseStream.Seek(8, SeekOrigin.Current); // Skip unknowns
                    DateTime TimeStart = new DateTime(1970, 1, 1).AddSeconds(Reader.ReadInt64());
                    DateTime TimeEnd = new DateTime(1970, 1, 1).AddSeconds(Reader.ReadInt64());
                    Reader.BaseStream.Seek(3, SeekOrigin.Current); // Skip unknowns
                    Utility.Log($"Block 00 Entry {i.ToString("D2")}: q{QuestID.ToString("D5")} available {TimeStart} UTC - {TimeEnd} UTC", Form);

                    // Fill lists
                    Form1.AvailabilityStart.Add(new KeyValuePair<int, DateTime>(QuestID, TimeStart));
                    Form1.AvailabilityEnd.Add(new KeyValuePair<int, DateTime>(QuestID, TimeEnd));
                }
            }
        }

        // Process Quest Data block (04)
        public static void ProcessBlock04(Form1 Form)
        {
            string InputFile = $"{Environment.CurrentDirectory}\\Blocks\\Block_04.bin";
            using (BinaryReader Reader = new BinaryReader(File.Open(InputFile, FileMode.Open)))
            {
                int ChunkCount = Reader.ReadInt32(); Utility.Log($"Block 04 Chunk Count: {ChunkCount}", Form);
                for (int i = 0, QuestID, FileCount, ChunkSize; i < ChunkCount; i++)
                {
                    // Read chunk header
                    QuestID = Reader.ReadInt32();
                    FileCount = Reader.ReadInt32();
                    ChunkSize = Reader.ReadInt32();
                    Utility.Log($"Block 04 Chunk {i.ToString("D4")}: q{QuestID.ToString("D5")} ({FileCount} files with total size 0x{ChunkSize.ToString("D8")})", Form);

                    for (int j = 0, FileSize; j < FileCount; j++)
                    {
                        FileSize = Reader.ReadInt32();
                        byte[] FileData = Reader.ReadBytes(FileSize);

                        // Extract GMD
                        string GmdLangTag = "";
                        if (FileData[0] == 0x47 && FileData[1] == 0x4D && FileData[2] == 0x44)
                        {
                            switch (FileData[8])
                            {
                                case 0: GmdLangTag = "jpn"; break;
                                case 1: GmdLangTag = "eng"; break;
                                case 2: GmdLangTag = "fre"; break;
                                case 3: GmdLangTag = "spa"; break;
                                case 4: GmdLangTag = "ger"; break;
                                case 5: GmdLangTag = "ita"; break;
                                case 6: GmdLangTag = "kor"; break;
                                case 7: GmdLangTag = "chT"; break;
                                case 8: GmdLangTag = "chS"; break;
                                case 10: GmdLangTag = "rus"; break;
                                case 11: GmdLangTag = "pol"; break;
                                case 21: GmdLangTag = "ptB"; break;
                                case 22: GmdLangTag = "ara"; break;
                                default: GmdLangTag = FileData[8].ToString("D3"); break;
                            }
                            File.WriteAllBytes($"{Environment.CurrentDirectory}\\tss\\quest\\text\\q{QuestID.ToString("D5")}_{GmdLangTag}.gmd", FileData);
                        }
                        // Extract MIB
                        else if (FileData.Length == 1008) File.WriteAllBytes($"{Environment.CurrentDirectory}\\tss\\quest\\questData_{QuestID.ToString("D5")}.mib", FileData);
                        // Extract acEquip
                        else if (FileData[0] == 0xAA && FileData[1] == 0x01 && FileData[2] == 0x05) File.WriteAllBytes($"{Environment.CurrentDirectory}\\tss\\quest\\acEquip\\acEquip_{QuestID.ToString("D5")}.aeq", FileData);
                        // Extract anything else
                        else File.WriteAllBytes($"Quest_{QuestID.ToString("D5")}\\{j.ToString("D2")}.bin", FileData);
                    }

                    // Add quest name to ComboBoxEntries and fill dict
                    string QuestName = Utility.GetQuestTitle($"{Environment.CurrentDirectory}\\tss\\quest\\text\\q{QuestID.ToString("D5")}_eng.gmd");
                    Form.ComboBoxEntries.Items.Add(QuestName);
                    Form1.EventQuests.Add(QuestID, QuestName);
                }
            }
        }
    }
}
