namespace Qubic_Resultfilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkboxShowOnlyFoundIDsInResultFiles = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCsvDelimiter = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSetOutputPath = new System.Windows.Forms.Button();
            this.outputDirectory = new System.Windows.Forms.TextBox();
            this.btnSetOwnIDsPath = new System.Windows.Forms.Button();
            this.ownIDsPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectRewardsFile = new System.Windows.Forms.Button();
            this.btnRunAgain = new System.Windows.Forms.Button();
            this.textBoxRewardsFile = new System.Windows.Forms.TextBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkboxShowOnlyFoundIDsInResultFiles);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxCsvDelimiter);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnSetOutputPath);
            this.groupBox1.Controls.Add(this.outputDirectory);
            this.groupBox1.Controls.Add(this.btnSetOwnIDsPath);
            this.groupBox1.Controls.Add(this.ownIDsPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkboxShowOnlyFoundIDsInResultFiles
            // 
            this.checkboxShowOnlyFoundIDsInResultFiles.AutoSize = true;
            this.checkboxShowOnlyFoundIDsInResultFiles.Checked = global::Qubic_Resultfilter.Properties.Settings.Default.showOwnIDsWithoutValueFound;
            this.checkboxShowOnlyFoundIDsInResultFiles.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Qubic_Resultfilter.Properties.Settings.Default, "showOwnIDsWithoutValueFound", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkboxShowOnlyFoundIDsInResultFiles.Location = new System.Drawing.Point(225, 101);
            this.checkboxShowOnlyFoundIDsInResultFiles.Name = "checkboxShowOnlyFoundIDsInResultFiles";
            this.checkboxShowOnlyFoundIDsInResultFiles.Size = new System.Drawing.Size(287, 17);
            this.checkboxShowOnlyFoundIDsInResultFiles.TabIndex = 9;
            this.checkboxShowOnlyFoundIDsInResultFiles.Text = "Also show own IDs without any found value in result file";
            this.checkboxShowOnlyFoundIDsInResultFiles.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CSV file delimiter (input and output):";
            // 
            // textBoxCsvDelimiter
            // 
            this.textBoxCsvDelimiter.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Qubic_Resultfilter.Properties.Settings.Default, "csvDelimiter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxCsvDelimiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCsvDelimiter.Location = new System.Drawing.Point(402, 67);
            this.textBoxCsvDelimiter.MaxLength = 2;
            this.textBoxCsvDelimiter.Name = "textBoxCsvDelimiter";
            this.textBoxCsvDelimiter.Size = new System.Drawing.Size(25, 31);
            this.textBoxCsvDelimiter.TabIndex = 7;
            this.textBoxCsvDelimiter.Text = global::Qubic_Resultfilter.Properties.Settings.Default.csvDelimiter;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::Qubic_Resultfilter.Properties.Settings.Default.autoProcessWhenDroppedOrLoaded;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Qubic_Resultfilter.Properties.Settings.Default, "autoProcessWhenDroppedOrLoaded", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(6, 101);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(196, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Auto-Process file after drop or select";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open output directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::Qubic_Resultfilter.Properties.Settings.Default.openFileAfterGeneration;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Qubic_Resultfilter.Properties.Settings.Default, "openFileAfterGeneration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(6, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(174, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Open result file after processing";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSetOutputPath
            // 
            this.btnSetOutputPath.Location = new System.Drawing.Point(509, 42);
            this.btnSetOutputPath.Name = "btnSetOutputPath";
            this.btnSetOutputPath.Size = new System.Drawing.Size(155, 23);
            this.btnSetOutputPath.TabIndex = 3;
            this.btnSetOutputPath.Text = "Set output directory";
            this.btnSetOutputPath.UseVisualStyleBackColor = true;
            this.btnSetOutputPath.Click += new System.EventHandler(this.btnSetOutputPath_Click);
            // 
            // outputDirectory
            // 
            this.outputDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Qubic_Resultfilter.Properties.Settings.Default, "outputFileDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.outputDirectory.Location = new System.Drawing.Point(6, 45);
            this.outputDirectory.Name = "outputDirectory";
            this.outputDirectory.ReadOnly = true;
            this.outputDirectory.Size = new System.Drawing.Size(497, 20);
            this.outputDirectory.TabIndex = 2;
            this.outputDirectory.Text = global::Qubic_Resultfilter.Properties.Settings.Default.outputFileDirectory;
            // 
            // btnSetOwnIDsPath
            // 
            this.btnSetOwnIDsPath.Location = new System.Drawing.Point(509, 16);
            this.btnSetOwnIDsPath.Name = "btnSetOwnIDsPath";
            this.btnSetOwnIDsPath.Size = new System.Drawing.Size(155, 23);
            this.btnSetOwnIDsPath.TabIndex = 1;
            this.btnSetOwnIDsPath.Text = "Set own IDs CSV path";
            this.btnSetOwnIDsPath.UseVisualStyleBackColor = true;
            this.btnSetOwnIDsPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // ownIDsPath
            // 
            this.ownIDsPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Qubic_Resultfilter.Properties.Settings.Default, "ownIDsPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ownIDsPath.Location = new System.Drawing.Point(6, 19);
            this.ownIDsPath.Name = "ownIDsPath";
            this.ownIDsPath.ReadOnly = true;
            this.ownIDsPath.Size = new System.Drawing.Size(497, 20);
            this.ownIDsPath.TabIndex = 0;
            this.ownIDsPath.Text = global::Qubic_Resultfilter.Properties.Settings.Default.ownIDsPath;
            this.ownIDsPath.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectRewardsFile);
            this.groupBox2.Controls.Add(this.btnRunAgain);
            this.groupBox2.Controls.Add(this.textBoxRewardsFile);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Latest Rewards / score file (Drag/Drop enabled)";
            this.groupBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragDrop);
            this.groupBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragEnter);
            // 
            // btnSelectRewardsFile
            // 
            this.btnSelectRewardsFile.Location = new System.Drawing.Point(509, 17);
            this.btnSelectRewardsFile.Name = "btnSelectRewardsFile";
            this.btnSelectRewardsFile.Size = new System.Drawing.Size(155, 23);
            this.btnSelectRewardsFile.TabIndex = 5;
            this.btnSelectRewardsFile.Text = "Select file manually";
            this.btnSelectRewardsFile.UseVisualStyleBackColor = true;
            this.btnSelectRewardsFile.Click += new System.EventHandler(this.btnSelectRewardsFile_Click);
            // 
            // btnRunAgain
            // 
            this.btnRunAgain.Location = new System.Drawing.Point(509, 45);
            this.btnRunAgain.Name = "btnRunAgain";
            this.btnRunAgain.Size = new System.Drawing.Size(155, 23);
            this.btnRunAgain.TabIndex = 3;
            this.btnRunAgain.Text = "Process file";
            this.btnRunAgain.UseVisualStyleBackColor = true;
            this.btnRunAgain.Click += new System.EventHandler(this.btnRunAgain_Click);
            // 
            // textBoxRewardsFile
            // 
            this.textBoxRewardsFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Qubic_Resultfilter.Properties.Settings.Default, "currentRewardsFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxRewardsFile.Location = new System.Drawing.Point(6, 19);
            this.textBoxRewardsFile.Name = "textBoxRewardsFile";
            this.textBoxRewardsFile.ReadOnly = true;
            this.textBoxRewardsFile.Size = new System.Drawing.Size(497, 20);
            this.textBoxRewardsFile.TabIndex = 0;
            this.textBoxRewardsFile.Text = global::Qubic_Resultfilter.Properties.Settings.Default.currentRewardsFile;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(6, 19);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(658, 134);
            this.listBoxLog.TabIndex = 4;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxLog);
            this.groupBox3.Location = new System.Drawing.Point(12, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(673, 164);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 401);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Qubic-Resultfilter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ownIDsPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSetOwnIDsPath;
        private System.Windows.Forms.TextBox outputDirectory;
        private System.Windows.Forms.Button btnSetOutputPath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRunAgain;
        private System.Windows.Forms.Button btnSelectRewardsFile;
        private System.Windows.Forms.TextBox textBoxRewardsFile;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCsvDelimiter;
        private System.Windows.Forms.CheckBox checkboxShowOnlyFoundIDsInResultFiles;
    }
}

