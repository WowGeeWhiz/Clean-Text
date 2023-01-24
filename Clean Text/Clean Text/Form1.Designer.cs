namespace Clean_Text
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.entryTextBox = new System.Windows.Forms.TextBox();
            this.entryLabel = new System.Windows.Forms.Label();
            this.headLabel = new System.Windows.Forms.Label();
            this.removeLabel = new System.Windows.Forms.Label();
            this.removeTextBox = new System.Windows.Forms.TextBox();
            this.replaceTextButton = new System.Windows.Forms.CheckBox();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.inputFromLoadButton = new System.Windows.Forms.Button();
            this.generateLogCheck = new System.Windows.Forms.CheckBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.removeFromLoadButton = new System.Windows.Forms.Button();
            this.replaceFromLoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // entryTextBox
            // 
            this.entryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryTextBox.Location = new System.Drawing.Point(12, 57);
            this.entryTextBox.Multiline = true;
            this.entryTextBox.Name = "entryTextBox";
            this.entryTextBox.PlaceholderText = "Enter original text here";
            this.entryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.entryTextBox.Size = new System.Drawing.Size(381, 108);
            this.entryTextBox.TabIndex = 0;
            this.entryTextBox.TextChanged += new System.EventHandler(this.entryTextBox_TextChanged);
            // 
            // entryLabel
            // 
            this.entryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryLabel.AutoSize = true;
            this.entryLabel.Location = new System.Drawing.Point(12, 39);
            this.entryLabel.Name = "entryLabel";
            this.entryLabel.Size = new System.Drawing.Size(76, 15);
            this.entryLabel.TabIndex = 1;
            this.entryLabel.Text = "Original Text:";
            // 
            // headLabel
            // 
            this.headLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headLabel.AutoSize = true;
            this.headLabel.Location = new System.Drawing.Point(105, 9);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(191, 15);
            this.headLabel.TabIndex = 2;
            this.headLabel.Text = "Ethan Johnson\'s Text Cleaning Tool";
            // 
            // removeLabel
            // 
            this.removeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLabel.AutoSize = true;
            this.removeLabel.Location = new System.Drawing.Point(12, 182);
            this.removeLabel.Name = "removeLabel";
            this.removeLabel.Size = new System.Drawing.Size(91, 15);
            this.removeLabel.TabIndex = 4;
            this.removeLabel.Text = "Text to Remove:";
            // 
            // removeTextBox
            // 
            this.removeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeTextBox.Location = new System.Drawing.Point(12, 200);
            this.removeTextBox.Multiline = true;
            this.removeTextBox.Name = "removeTextBox";
            this.removeTextBox.PlaceholderText = "Enter text you want to remove";
            this.removeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.removeTextBox.Size = new System.Drawing.Size(381, 44);
            this.removeTextBox.TabIndex = 3;
            this.removeTextBox.TextChanged += new System.EventHandler(this.removeTextBox_TextChanged);
            // 
            // replaceTextButton
            // 
            this.replaceTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceTextButton.AutoSize = true;
            this.replaceTextButton.Location = new System.Drawing.Point(12, 262);
            this.replaceTextButton.Name = "replaceTextButton";
            this.replaceTextButton.Size = new System.Drawing.Size(94, 19);
            this.replaceTextButton.TabIndex = 5;
            this.replaceTextButton.Text = "Replace Text:";
            this.replaceTextButton.UseVisualStyleBackColor = true;
            this.replaceTextButton.CheckedChanged += new System.EventHandler(this.replaceTextButton_CheckedChanged);
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceTextBox.Location = new System.Drawing.Point(12, 287);
            this.replaceTextBox.Multiline = true;
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.PlaceholderText = "Enter text you want to replace the removed text with";
            this.replaceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.replaceTextBox.Size = new System.Drawing.Size(381, 44);
            this.replaceTextBox.TabIndex = 6;
            this.replaceTextBox.TextChanged += new System.EventHandler(this.replaceTextBox_TextChanged);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.Location = new System.Drawing.Point(317, 416);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(93, 416);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(12, 387);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset Form";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(12, 416);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // inputFromLoadButton
            // 
            this.inputFromLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFromLoadButton.Location = new System.Drawing.Point(254, 30);
            this.inputFromLoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputFromLoadButton.Name = "inputFromLoadButton";
            this.inputFromLoadButton.Size = new System.Drawing.Size(138, 22);
            this.inputFromLoadButton.TabIndex = 11;
            this.inputFromLoadButton.Text = "Load From File";
            this.inputFromLoadButton.UseVisualStyleBackColor = true;
            this.inputFromLoadButton.Click += new System.EventHandler(this.inputFromLoadButton_Click);
            // 
            // generateLogCheck
            // 
            this.generateLogCheck.AutoSize = true;
            this.generateLogCheck.Location = new System.Drawing.Point(206, 419);
            this.generateLogCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateLogCheck.Name = "generateLogCheck";
            this.generateLogCheck.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.generateLogCheck.Size = new System.Drawing.Size(96, 19);
            this.generateLogCheck.TabIndex = 12;
            this.generateLogCheck.Text = "Generate Log";
            this.generateLogCheck.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(93, 389);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 22);
            this.settingsButton.TabIndex = 13;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // removeFromLoadButton
            // 
            this.removeFromLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeFromLoadButton.Location = new System.Drawing.Point(254, 173);
            this.removeFromLoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeFromLoadButton.Name = "removeFromLoadButton";
            this.removeFromLoadButton.Size = new System.Drawing.Size(138, 22);
            this.removeFromLoadButton.TabIndex = 14;
            this.removeFromLoadButton.Text = "Load From File";
            this.removeFromLoadButton.UseVisualStyleBackColor = true;
            this.removeFromLoadButton.Click += new System.EventHandler(this.removeFromLoadButton_Click);
            // 
            // replaceFromLoadButton
            // 
            this.replaceFromLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceFromLoadButton.Location = new System.Drawing.Point(254, 260);
            this.replaceFromLoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.replaceFromLoadButton.Name = "replaceFromLoadButton";
            this.replaceFromLoadButton.Size = new System.Drawing.Size(138, 22);
            this.replaceFromLoadButton.TabIndex = 15;
            this.replaceFromLoadButton.Text = "Load From File";
            this.replaceFromLoadButton.UseVisualStyleBackColor = true;
            this.replaceFromLoadButton.Click += new System.EventHandler(this.replaceFromLoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 451);
            this.Controls.Add(this.replaceFromLoadButton);
            this.Controls.Add(this.removeFromLoadButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.generateLogCheck);
            this.Controls.Add(this.inputFromLoadButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.replaceTextButton);
            this.Controls.Add(this.removeLabel);
            this.Controls.Add(this.removeTextBox);
            this.Controls.Add(this.headLabel);
            this.Controls.Add(this.entryLabel);
            this.Controls.Add(this.entryTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(419, 488);
            this.Name = "Form1";
            this.Text = "Text Cleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox entryTextBox;
        private Label entryLabel;
        private Label headLabel;
        private Label removeLabel;
        private TextBox removeTextBox;
        private CheckBox replaceTextButton;
        private TextBox replaceTextBox;
        private Button runButton;
        private Button helpButton;
        private Button resetButton;
        private Button closeButton;
        private Button inputFromLoadButton;
        private CheckBox generateLogCheck;
        private Button settingsButton;
        private Button removeFromLoadButton;
        private Button replaceFromLoadButton;
    }
}