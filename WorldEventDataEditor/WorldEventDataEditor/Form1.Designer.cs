namespace WorldEventDataEditor
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageEditor = new System.Windows.Forms.TabPage();
            this.ButtonRemoveEntry = new System.Windows.Forms.Button();
            this.ButtonAddEntry = new System.Windows.Forms.Button();
            this.DateTimePickerEnd2 = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerStart2 = new System.Windows.Forms.DateTimePicker();
            this.LabelAvailability = new System.Windows.Forms.Label();
            this.DateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.NumericQuestID = new System.Windows.Forms.NumericUpDown();
            this.ComboBoxEntries = new System.Windows.Forms.ComboBox();
            this.LabelEntrySelect = new System.Windows.Forms.Label();
            this.TabPageLog = new System.Windows.Forms.TabPage();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabPageEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericQuestID)).BeginInit();
            this.TabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.RestoreBackupToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // RestoreBackupToolStripMenuItem
            // 
            this.RestoreBackupToolStripMenuItem.Enabled = false;
            this.RestoreBackupToolStripMenuItem.Name = "RestoreBackupToolStripMenuItem";
            this.RestoreBackupToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.RestoreBackupToolStripMenuItem.Text = "Restore Backup";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "data.bin";
            this.OpenFileDialog.Filter = "tss data|data*.*";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageEditor);
            this.TabControl.Controls.Add(this.TabPageLog);
            this.TabControl.Location = new System.Drawing.Point(13, 28);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(775, 410);
            this.TabControl.TabIndex = 1;
            // 
            // TabPageEditor
            // 
            this.TabPageEditor.Controls.Add(this.ButtonRemoveEntry);
            this.TabPageEditor.Controls.Add(this.ButtonAddEntry);
            this.TabPageEditor.Controls.Add(this.DateTimePickerEnd2);
            this.TabPageEditor.Controls.Add(this.DateTimePickerStart2);
            this.TabPageEditor.Controls.Add(this.LabelAvailability);
            this.TabPageEditor.Controls.Add(this.DateTimePickerEnd);
            this.TabPageEditor.Controls.Add(this.DateTimePickerStart);
            this.TabPageEditor.Controls.Add(this.NumericQuestID);
            this.TabPageEditor.Controls.Add(this.ComboBoxEntries);
            this.TabPageEditor.Controls.Add(this.LabelEntrySelect);
            this.TabPageEditor.Location = new System.Drawing.Point(4, 22);
            this.TabPageEditor.Name = "TabPageEditor";
            this.TabPageEditor.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageEditor.Size = new System.Drawing.Size(767, 384);
            this.TabPageEditor.TabIndex = 0;
            this.TabPageEditor.Text = "Editor";
            this.TabPageEditor.UseVisualStyleBackColor = true;
            // 
            // ButtonRemoveEntry
            // 
            this.ButtonRemoveEntry.Location = new System.Drawing.Point(512, 6);
            this.ButtonRemoveEntry.Name = "ButtonRemoveEntry";
            this.ButtonRemoveEntry.Size = new System.Drawing.Size(99, 23);
            this.ButtonRemoveEntry.TabIndex = 9;
            this.ButtonRemoveEntry.Text = "Remove Entry";
            this.ButtonRemoveEntry.UseVisualStyleBackColor = true;
            // 
            // ButtonAddEntry
            // 
            this.ButtonAddEntry.Location = new System.Drawing.Point(407, 6);
            this.ButtonAddEntry.Name = "ButtonAddEntry";
            this.ButtonAddEntry.Size = new System.Drawing.Size(99, 23);
            this.ButtonAddEntry.TabIndex = 8;
            this.ButtonAddEntry.Text = "Add Entry";
            this.ButtonAddEntry.UseVisualStyleBackColor = true;
            this.ButtonAddEntry.Click += new System.EventHandler(this.ButtonAddEntry_Click);
            // 
            // DateTimePickerEnd2
            // 
            this.DateTimePickerEnd2.Location = new System.Drawing.Point(281, 61);
            this.DateTimePickerEnd2.Name = "DateTimePickerEnd2";
            this.DateTimePickerEnd2.Size = new System.Drawing.Size(194, 20);
            this.DateTimePickerEnd2.TabIndex = 7;
            // 
            // DateTimePickerStart2
            // 
            this.DateTimePickerStart2.Location = new System.Drawing.Point(81, 61);
            this.DateTimePickerStart2.Name = "DateTimePickerStart2";
            this.DateTimePickerStart2.Size = new System.Drawing.Size(194, 20);
            this.DateTimePickerStart2.TabIndex = 6;
            // 
            // LabelAvailability
            // 
            this.LabelAvailability.AutoSize = true;
            this.LabelAvailability.Location = new System.Drawing.Point(8, 41);
            this.LabelAvailability.Name = "LabelAvailability";
            this.LabelAvailability.Size = new System.Drawing.Size(59, 13);
            this.LabelAvailability.TabIndex = 5;
            this.LabelAvailability.Text = "Availability:";
            // 
            // DateTimePickerEnd
            // 
            this.DateTimePickerEnd.Location = new System.Drawing.Point(281, 35);
            this.DateTimePickerEnd.Name = "DateTimePickerEnd";
            this.DateTimePickerEnd.Size = new System.Drawing.Size(194, 20);
            this.DateTimePickerEnd.TabIndex = 4;
            // 
            // DateTimePickerStart
            // 
            this.DateTimePickerStart.Location = new System.Drawing.Point(81, 35);
            this.DateTimePickerStart.Name = "DateTimePickerStart";
            this.DateTimePickerStart.Size = new System.Drawing.Size(194, 20);
            this.DateTimePickerStart.TabIndex = 3;
            // 
            // NumericQuestID
            // 
            this.NumericQuestID.Enabled = false;
            this.NumericQuestID.Location = new System.Drawing.Point(281, 8);
            this.NumericQuestID.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.NumericQuestID.Name = "NumericQuestID";
            this.NumericQuestID.Size = new System.Drawing.Size(120, 20);
            this.NumericQuestID.TabIndex = 2;
            // 
            // ComboBoxEntries
            // 
            this.ComboBoxEntries.FormattingEnabled = true;
            this.ComboBoxEntries.Location = new System.Drawing.Point(81, 7);
            this.ComboBoxEntries.Name = "ComboBoxEntries";
            this.ComboBoxEntries.Size = new System.Drawing.Size(194, 21);
            this.ComboBoxEntries.TabIndex = 1;
            this.ComboBoxEntries.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEntries_SelectedIndexChanged);
            // 
            // LabelEntrySelect
            // 
            this.LabelEntrySelect.AutoSize = true;
            this.LabelEntrySelect.Location = new System.Drawing.Point(8, 10);
            this.LabelEntrySelect.Name = "LabelEntrySelect";
            this.LabelEntrySelect.Size = new System.Drawing.Size(67, 13);
            this.LabelEntrySelect.TabIndex = 0;
            this.LabelEntrySelect.Text = "Select Entry:";
            // 
            // TabPageLog
            // 
            this.TabPageLog.Controls.Add(this.TextBoxLog);
            this.TabPageLog.Location = new System.Drawing.Point(4, 22);
            this.TabPageLog.Name = "TabPageLog";
            this.TabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLog.Size = new System.Drawing.Size(767, 384);
            this.TabPageLog.TabIndex = 1;
            this.TabPageLog.Text = "Log";
            this.TabPageLog.UseVisualStyleBackColor = true;
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.TextBoxLog.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxLog.Size = new System.Drawing.Size(767, 384);
            this.TextBoxLog.TabIndex = 1;
            this.TextBoxLog.WordWrap = false;
            this.TextBoxLog.VisibleChanged += new System.EventHandler(this.TextBoxLog_VisibleChanged);
            // 
            // LabelStatus
            // 
            this.LabelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelStatus.Location = new System.Drawing.Point(728, 440);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(60, 13);
            this.LabelStatus.TabIndex = 2;
            this.LabelStatus.Text = "Ready.";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.FileName = "data.bin";
            this.SaveFileDialog.Filter = "tss data|*.bin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Form1";
            this.Text = "WorldEventDataEditor by MHVuze";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabPageEditor.ResumeLayout(false);
            this.TabPageEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericQuestID)).EndInit();
            this.TabPageLog.ResumeLayout(false);
            this.TabPageLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreBackupToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageEditor;
        private System.Windows.Forms.TabPage TabPageLog;
        private System.Windows.Forms.Label LabelEntrySelect;
        public System.Windows.Forms.ComboBox ComboBoxEntries;
        public System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.NumericUpDown NumericQuestID;
        private System.Windows.Forms.Label LabelAvailability;
        private System.Windows.Forms.DateTimePicker DateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker DateTimePickerStart;
        private System.Windows.Forms.DateTimePicker DateTimePickerEnd2;
        private System.Windows.Forms.DateTimePicker DateTimePickerStart2;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.Button ButtonRemoveEntry;
        private System.Windows.Forms.Button ButtonAddEntry;
    }
}

