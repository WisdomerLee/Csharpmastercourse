namespace WinFormsApp1
{


    partial class MainForm
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
            MinValue = new Label();
            MaxValue = new Label();
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            CheckInteger = new CheckBox();
            CheckPrecise = new CheckBox();
            SuggestType = new Label();
            SuggestTypeResult = new Label();
            SuspendLayout();
            // 
            // MinValue
            // 
            MinValue.AutoSize = true;
            MinValue.Location = new Point(12, 9);
            MinValue.Name = "MinValue";
            MinValue.Size = new Size(62, 15);
            MinValue.TabIndex = 0;
            MinValue.Text = "Min Value";
            // 
            // MaxValue
            // 
            MaxValue.AutoSize = true;
            MaxValue.Location = new Point(12, 35);
            MaxValue.Name = "MaxValue";
            MaxValue.Size = new Size(64, 15);
            MaxValue.TabIndex = 1;
            MaxValue.Text = "Max Value";
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Location = new Point(119, 8);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(349, 23);
            MinValueTextBox.TabIndex = 4;
            MinValueTextBox.TextChanged += ValueTextBox_TextChanged;
            MinValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Location = new Point(119, 35);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(349, 23);
            MaxValueTextBox.TabIndex = 5;
            MaxValueTextBox.TextChanged += ValueTextBox_TextChanged;
            MaxValueTextBox.KeyPress += TextBox_KeyPress;
            // 
            // CheckInteger
            // 
            CheckInteger.AutoSize = true;
            CheckInteger.CheckAlign = ContentAlignment.MiddleRight;
            CheckInteger.Checked = true;
            CheckInteger.CheckState = CheckState.Checked;
            CheckInteger.Location = new Point(12, 68);
            CheckInteger.Name = "CheckInteger";
            CheckInteger.Size = new Size(99, 19);
            CheckInteger.TabIndex = 6;
            CheckInteger.Text = "Integral only?";
            CheckInteger.TextAlign = ContentAlignment.MiddleRight;
            CheckInteger.UseVisualStyleBackColor = true;
            CheckInteger.CheckedChanged += CheckInteger_CheckedChanged;
            // 
            // CheckPrecise
            // 
            CheckPrecise.AutoSize = true;
            CheckPrecise.CheckAlign = ContentAlignment.MiddleRight;
            CheckPrecise.Location = new Point(12, 93);
            CheckPrecise.Name = "CheckPrecise";
            CheckPrecise.Size = new Size(117, 19);
            CheckPrecise.TabIndex = 7;
            CheckPrecise.Text = "Must be precise?";
            CheckPrecise.UseVisualStyleBackColor = true;
            CheckPrecise.CheckedChanged += CheckPrecise_CheckedChanged;
            // 
            // SuggestType
            // 
            SuggestType.AutoSize = true;
            SuggestType.Location = new Point(12, 115);
            SuggestType.Name = "SuggestType";
            SuggestType.Size = new Size(93, 15);
            SuggestType.TabIndex = 8;
            SuggestType.Text = "Suggested type:";
            // 
            // SuggestTypeResult
            // 
            SuggestTypeResult.AutoSize = true;
            SuggestTypeResult.Location = new Point(102, 115);
            SuggestTypeResult.Name = "SuggestTypeResult";
            SuggestTypeResult.Size = new Size(97, 15);
            SuggestTypeResult.TabIndex = 9;
            SuggestTypeResult.Text = "not enough data";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 139);
            Controls.Add(SuggestTypeResult);
            Controls.Add(SuggestType);
            Controls.Add(CheckPrecise);
            Controls.Add(CheckInteger);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Controls.Add(MaxValue);
            Controls.Add(MinValue);
            Name = "MainForm";
            Text = "Numeric";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MinValue;
        private Label MaxValue;
        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
        private CheckBox CheckInteger;
        private CheckBox CheckPrecise;
        private Label SuggestType;
        private Label SuggestTypeResult;
    }
}