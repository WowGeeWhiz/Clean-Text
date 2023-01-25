namespace Clean_Text
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.settingsLabel = new System.Windows.Forms.Label();
            this.outputLogGroup = new System.Windows.Forms.GroupBox();
            this.outputAsTxtCheckBox = new System.Windows.Forms.CheckBox();
            this.generateEventLogCheckBox = new System.Windows.Forms.CheckBox();
            this.outputSeparateCheckBox = new System.Windows.Forms.CheckBox();
            this.outputCleanedCheckBox = new System.Windows.Forms.CheckBox();
            this.outputReplaceCheckBox = new System.Windows.Forms.CheckBox();
            this.outputRemovedCheckBox = new System.Windows.Forms.CheckBox();
            this.outputOriginalCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.revertButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.outputLogGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Location = new System.Drawing.Point(186, 9);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(49, 15);
            this.settingsLabel.TabIndex = 0;
            this.settingsLabel.Text = "Settings";
            // 
            // outputLogGroup
            // 
            this.outputLogGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLogGroup.Controls.Add(this.outputAsTxtCheckBox);
            this.outputLogGroup.Controls.Add(this.generateEventLogCheckBox);
            this.outputLogGroup.Controls.Add(this.outputSeparateCheckBox);
            this.outputLogGroup.Controls.Add(this.outputCleanedCheckBox);
            this.outputLogGroup.Controls.Add(this.outputReplaceCheckBox);
            this.outputLogGroup.Controls.Add(this.outputRemovedCheckBox);
            this.outputLogGroup.Controls.Add(this.outputOriginalCheckBox);
            this.outputLogGroup.Controls.Add(this.label1);
            this.outputLogGroup.Controls.Add(this.outputDirectoryTextBox);
            this.outputLogGroup.Location = new System.Drawing.Point(12, 27);
            this.outputLogGroup.Name = "outputLogGroup";
            this.outputLogGroup.Size = new System.Drawing.Size(382, 173);
            this.outputLogGroup.TabIndex = 1;
            this.outputLogGroup.TabStop = false;
            this.outputLogGroup.Text = "Outputting Logs";
            // 
            // outputAsTxtCheckBox
            // 
            this.outputAsTxtCheckBox.AutoSize = true;
            this.outputAsTxtCheckBox.Location = new System.Drawing.Point(227, 73);
            this.outputAsTxtCheckBox.Name = "outputAsTxtCheckBox";
            this.outputAsTxtCheckBox.Size = new System.Drawing.Size(113, 19);
            this.outputAsTxtCheckBox.TabIndex = 5;
            this.outputAsTxtCheckBox.Text = "Output all as .txt";
            this.outputAsTxtCheckBox.UseVisualStyleBackColor = true;
            this.outputAsTxtCheckBox.CheckedChanged += new System.EventHandler(this.outputAsTxtCheckBox_CheckedChanged);
            // 
            // generateEventLogCheckBox
            // 
            this.generateEventLogCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateEventLogCheckBox.AutoSize = true;
            this.generateEventLogCheckBox.Location = new System.Drawing.Point(6, 148);
            this.generateEventLogCheckBox.Name = "generateEventLogCheckBox";
            this.generateEventLogCheckBox.Size = new System.Drawing.Size(128, 19);
            this.generateEventLogCheckBox.TabIndex = 8;
            this.generateEventLogCheckBox.Text = "Generate Event Log";
            this.generateEventLogCheckBox.UseVisualStyleBackColor = true;
            this.generateEventLogCheckBox.CheckedChanged += new System.EventHandler(this.generateEventLogCheckBox_CheckedChanged);
            // 
            // outputSeparateCheckBox
            // 
            this.outputSeparateCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputSeparateCheckBox.AutoSize = true;
            this.outputSeparateCheckBox.Location = new System.Drawing.Point(227, 48);
            this.outputSeparateCheckBox.Name = "outputSeparateCheckBox";
            this.outputSeparateCheckBox.Size = new System.Drawing.Size(149, 19);
            this.outputSeparateCheckBox.TabIndex = 3;
            this.outputSeparateCheckBox.Text = "Output to separate files";
            this.outputSeparateCheckBox.UseVisualStyleBackColor = true;
            this.outputSeparateCheckBox.CheckedChanged += new System.EventHandler(this.outputSeparateCheckBox_CheckedChanged);
            // 
            // outputCleanedCheckBox
            // 
            this.outputCleanedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputCleanedCheckBox.AutoSize = true;
            this.outputCleanedCheckBox.Location = new System.Drawing.Point(6, 123);
            this.outputCleanedCheckBox.Name = "outputCleanedCheckBox";
            this.outputCleanedCheckBox.Size = new System.Drawing.Size(131, 19);
            this.outputCleanedCheckBox.TabIndex = 7;
            this.outputCleanedCheckBox.Text = "Output cleaned text";
            this.outputCleanedCheckBox.UseVisualStyleBackColor = true;
            this.outputCleanedCheckBox.CheckedChanged += new System.EventHandler(this.outputCleanedCheckBox_CheckedChanged);
            // 
            // outputReplaceCheckBox
            // 
            this.outputReplaceCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputReplaceCheckBox.AutoSize = true;
            this.outputReplaceCheckBox.Location = new System.Drawing.Point(6, 98);
            this.outputReplaceCheckBox.Name = "outputReplaceCheckBox";
            this.outputReplaceCheckBox.Size = new System.Drawing.Size(156, 19);
            this.outputReplaceCheckBox.TabIndex = 6;
            this.outputReplaceCheckBox.Text = "Output replacement text";
            this.outputReplaceCheckBox.UseVisualStyleBackColor = true;
            this.outputReplaceCheckBox.CheckedChanged += new System.EventHandler(this.outputReplaceCheckBox_CheckedChanged);
            // 
            // outputRemovedCheckBox
            // 
            this.outputRemovedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRemovedCheckBox.AutoSize = true;
            this.outputRemovedCheckBox.Location = new System.Drawing.Point(6, 73);
            this.outputRemovedCheckBox.Name = "outputRemovedCheckBox";
            this.outputRemovedCheckBox.Size = new System.Drawing.Size(137, 19);
            this.outputRemovedCheckBox.TabIndex = 4;
            this.outputRemovedCheckBox.Text = "Output removed text";
            this.outputRemovedCheckBox.UseVisualStyleBackColor = true;
            this.outputRemovedCheckBox.CheckedChanged += new System.EventHandler(this.outputRemovedCheckBox_CheckedChanged);
            // 
            // outputOriginalCheckBox
            // 
            this.outputOriginalCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputOriginalCheckBox.AutoSize = true;
            this.outputOriginalCheckBox.Location = new System.Drawing.Point(6, 48);
            this.outputOriginalCheckBox.Name = "outputOriginalCheckBox";
            this.outputOriginalCheckBox.Size = new System.Drawing.Size(130, 19);
            this.outputOriginalCheckBox.TabIndex = 2;
            this.outputOriginalCheckBox.Text = "Output original text";
            this.outputOriginalCheckBox.UseVisualStyleBackColor = true;
            this.outputOriginalCheckBox.CheckedChanged += new System.EventHandler(this.outputOriginalCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output Directory:";
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(108, 22);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(268, 23);
            this.outputDirectoryTextBox.TabIndex = 1;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(319, 574);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // revertButton
            // 
            this.revertButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.revertButton.Location = new System.Drawing.Point(238, 574);
            this.revertButton.Name = "revertButton";
            this.revertButton.Size = new System.Drawing.Size(75, 23);
            this.revertButton.TabIndex = 10;
            this.revertButton.Text = "Undo";
            this.revertButton.UseVisualStyleBackColor = true;
            this.revertButton.Click += new System.EventHandler(this.revertButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(12, 574);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 609);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.revertButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.outputLogGroup);
            this.Controls.Add(this.settingsLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(422, 648);
            this.Name = "Form3";
            this.Text = "Text Cleaner";
            this.outputLogGroup.ResumeLayout(false);
            this.outputLogGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label settingsLabel;
        private GroupBox outputLogGroup;
        private Label label1;
        private TextBox outputDirectoryTextBox;
        private CheckBox generateEventLogCheckBox;
        private CheckBox outputSeparateCheckBox;
        private CheckBox outputCleanedCheckBox;
        private CheckBox outputReplaceCheckBox;
        private CheckBox outputRemovedCheckBox;
        private CheckBox outputOriginalCheckBox;
        private Button applyButton;
        private Button revertButton;
        private Button closeButton;
        private CheckBox outputAsTxtCheckBox;
    }
}