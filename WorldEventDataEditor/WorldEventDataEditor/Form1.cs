using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldEventDataEditor
{
    public partial class Form1 : Form
    {
        string EventDataFile;
        byte[] FileBuild;

        public static Dictionary<int, string> EventQuests = new Dictionary<int, string>();
        public static List<KeyValuePair<int, DateTime>> AvailabilityStart = new List<KeyValuePair<int, DateTime>>();
        public static List<KeyValuePair<int, DateTime>> AvailabilityEnd = new List<KeyValuePair<int, DateTime>>();
        ILookup<int, DateTime> LookUpStart; ILookup<int, DateTime> LookUpEnd;

        public Form1()
        {
            // Create all necessary directories
            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Blocks\\");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Output\\");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\tss\\quest\\text");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}\\tss\\quest\\acEquip");

            InitializeComponent();
            Utility.Log("Initialized WorldEventDataEditor by MHVuze", this);
            Utility.Log("Major contributions and research by v00d00y", this);

            //OpenFileDialog.InitialDirectory = SaveFileDialog.InitialDirectory = Utility.GetGameInstallDir() + "\\tss";
            OpenFileDialog.InitialDirectory = @"F:\MHWorld_PC\Backup\";
            Utility.Log($"Set initial directory to {OpenFileDialog.InitialDirectory}", this);

            // Todo: Check for backup
        }

        // Process file (decrypt, extract...)
        private void ProcessEventDataFile(string InputFile)
        {
            // Decrypt data
            byte[] EncryptedFile = File.ReadAllBytes(InputFile);
            byte[] DecryptedFile = Crypto.DecryptTss(EncryptedFile);

            // Extract blocks
            using (MemoryStream Stream = new MemoryStream(DecryptedFile))
            {
                using (BinaryReader Reader = new BinaryReader(Stream))
                {
                    // Read header
                    Utility.Log($"Checksum: {Reader.ReadInt32().ToString("X4")}", this);
                    int Build = Reader.ReadInt32(); FileBuild = BitConverter.GetBytes(Build);
                    Utility.Log($"Build: {Build.ToString("X4")}", this);
                    int DataSize = Reader.ReadInt32(); Utility.Log($"Data size: 0x{DataSize.ToString("X8")}", this);
                    int BlockOffset = Reader.ReadInt32(); Utility.Log($"Block Start Offset: 0x{BlockOffset.ToString("X8")}", this);
                    int BlockCount = Reader.ReadInt32(); Utility.Log($"Block Count: {BlockCount}", this);

                    // Ask to overwrite
                    if (Directory.GetFiles($"{ Environment.CurrentDirectory}\\Blocks\\").Count() != 0)
                    {
                        DialogResult Result = MessageBox.Show("Blocks directory is not empty. Keep old files?", "Warning", MessageBoxButtons.YesNo);
                        if (Result == DialogResult.Yes) Utility.Log("Using existing block files.", this);
                        else if (Result == DialogResult.No)
                        {
                            // Get block data
                            for (int i = 0, TotalSize = 0, Pos = 0; i < BlockCount; i++)
                            {
                                // Get block size
                                int BlockSize = Reader.ReadInt32(); Utility.Log($"Block {i.ToString("D2")} Size: {BlockSize.ToString("X8")}", this);
                                Pos = (int)Reader.BaseStream.Position;

                                // Read block data
                                Reader.BaseStream.Seek(BlockOffset + TotalSize, SeekOrigin.Begin);
                                byte[] BlockData = Reader.ReadBytes(BlockSize);
                                File.WriteAllBytes($"{Environment.CurrentDirectory}\\Blocks\\Block_{i.ToString("D2")}.bin", BlockData);

                                // Prepare for next loop
                                Reader.BaseStream.Seek(Pos, SeekOrigin.Begin);
                                TotalSize += BlockSize;
                            }
                        }
                    }
                    // No blocks exist
                    else
                    {
                        // Get block data
                        for (int i = 0, TotalSize = 0, Pos = 0; i < BlockCount; i++)
                        {
                            // Get block size
                            int BlockSize = Reader.ReadInt32(); Utility.Log($"Block {i.ToString("D2")} Size: {BlockSize.ToString("X8")}", this);
                            Pos = (int)Reader.BaseStream.Position;

                            // Read block data
                            Reader.BaseStream.Seek(BlockOffset + TotalSize, SeekOrigin.Begin);
                            byte[] BlockData = Reader.ReadBytes(BlockSize);
                            File.WriteAllBytes($"{Environment.CurrentDirectory}\\Blocks\\Block_{i.ToString("D2")}.bin", BlockData);

                            // Prepare for next loop
                            Reader.BaseStream.Seek(Pos, SeekOrigin.Begin);
                            TotalSize += BlockSize;
                        }
                    }
                }
            }

            // Process blocks
            Block.ProcessBlock04(this); Utility.Log($"Event Quest Dictionary now contains {EventQuests.Count} entries", this);
            Block.ProcessBlock00(this); Utility.Log($"Time Table Start list now contains {AvailabilityStart.Count} entries", this); Utility.Log($"Time Table End list now contains {AvailabilityEnd.Count} entries", this);

            LookUpStart = AvailabilityStart.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
            LookUpEnd = AvailabilityEnd.ToLookup(kvp => kvp.Key, kvp => kvp.Value);
            LabelStatus.Text = "Ready.";
        }

        // Open File
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                LabelStatus.Text = "Working..."; Refresh();
                EventDataFile = OpenFileDialog.FileName;
                Utility.Log($"File: {EventDataFile}", this);                
                ProcessEventDataFile(EventDataFile);
                SaveToolStripMenuItem.Enabled = true; OpenToolStripMenuItem.Enabled = false;
            }
        }

        // Save File
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] InputFiles = Directory.GetFiles($"{Environment.CurrentDirectory}\\Blocks\\", "*.bin");

            if (SaveFileDialog.ShowDialog() == DialogResult.OK && InputFiles.Count() == 11)
            {
                // Merge files
                MemoryStream OutputStream = new MemoryStream();
                foreach (string InputFile in InputFiles) using (FileStream InputStream = File.OpenRead(InputFile)) InputStream.CopyTo(OutputStream);

                // Re-create header
                byte[] DecryptedData = new byte[OutputStream.Length + 0x44];                
                FileBuild.CopyTo(DecryptedData, 4);
                BitConverter.GetBytes(OutputStream.Length + 0x30).CopyTo(DecryptedData, 8); // Todo: Check again why 0x30
                Utility.Log($"New Data Size: 0x{(OutputStream.Length + 0x30).ToString("X8")}", this);
                BitConverter.GetBytes(0x44).CopyTo(DecryptedData, 0x0C);
                BitConverter.GetBytes(11).CopyTo(DecryptedData, 0x10);

                // Re-create block table
                for (int i = 0; i < 11; i++) BitConverter.GetBytes(new FileInfo($"{Environment.CurrentDirectory}\\Blocks\\Block_{i.ToString("D2")}.bin").Length).CopyTo(DecryptedData, 0x14 + i * 4);

                // Copy merged file data to array
                OutputStream.ToArray().CopyTo(DecryptedData, 0x44);
                OutputStream.Close();

                // Calculate CRC
                CRC16_CCITT Crc = new CRC16_CCITT(InitialCrcValue.NonZero1);
                byte[] Temp = new byte[DecryptedData.Length - 0x0C]; Array.Copy(DecryptedData, 0x0C, Temp, 0, DecryptedData.Length - 0x0C);
                byte[] Checksum = Crc.ComputeChecksumBytes(Temp);
                Checksum.CopyTo(DecryptedData, 0);
                Utility.Log($"New Checksum: {BitConverter.ToInt16(Checksum, 0).ToString("X4")}", this);

                // Encrypt
                byte[] EncryptedData = Crypto.EncryptTSS(DecryptedData);
                File.WriteAllBytes(SaveFileDialog.FileName, EncryptedData);
                Utility.Log($"Saved to {SaveFileDialog.FileName}", this);
            }
            else
            {
                MessageBox.Show("Block count is incorrect. Please check the Blocks directory.");
                Utility.Log($"Saving failed due to block count mismatch.", this);
                return;
            }
        }

        // Scroll to bottom if TextBoxLog is visible
        private void TextBoxLog_VisibleChanged(object sender, EventArgs e)
        {
            if (TextBoxLog.Visible)
            {
                TextBoxLog.SelectionStart = TextBoxLog.TextLength;
                TextBoxLog.ScrollToCaret();
            }
        }

        // ComboBoxEntry selection changes
        private void ComboBoxEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumericQuestID.Value = EventQuests.FirstOrDefault(x => x.Value == ComboBoxEntries.SelectedItem.ToString()).Key;

            if (LookUpStart[(int)NumericQuestID.Value].Count() == 1)
            {
                DateTimePickerStart.Value = LookUpStart[(int)NumericQuestID.Value].ElementAt(0);
                DateTimePickerEnd.Value = LookUpEnd[(int)NumericQuestID.Value].ElementAt(0);
                DateTimePickerStart2.Visible = false; DateTimePickerEnd2.Visible = false;
            } else if (LookUpStart[(int)NumericQuestID.Value].Count() == 2)
            {
                DateTimePickerStart2.Visible = true; DateTimePickerEnd2.Visible = true;
                DateTimePickerStart.Value = LookUpStart[(int)NumericQuestID.Value].ElementAt(0);
                DateTimePickerEnd.Value = LookUpEnd[(int)NumericQuestID.Value].ElementAt(0);
                DateTimePickerStart2.Value = LookUpStart[(int)NumericQuestID.Value].ElementAt(1);
                DateTimePickerEnd2.Value = LookUpEnd[(int)NumericQuestID.Value].ElementAt(1);
            } else MessageBox.Show($"Amount of dates for this quest is: {LookUpStart[(int)NumericQuestID.Value].Count()}");
        }

        // Add entry
        private void ButtonAddEntry_Click(object sender, EventArgs e)
        {

        }
    }
}
