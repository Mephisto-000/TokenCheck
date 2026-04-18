namespace TokenCheckApp
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
        /// <param name="disposing">true if managed resources are being disposed; otherwise, false.</param>
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
            mainLayoutPanel = new TableLayoutPanel();
            topPanel = new TableLayoutPanel();
            apiKeyLabel = new Label();
            apiKeyTextBox = new TextBox();
            modelLabel = new Label();
            modelComboBox = new ComboBox();
            buttonPanel = new FlowLayoutPanel();
            countButton = new Button();
            clearButton = new Button();
            promptGroupBox = new GroupBox();
            promptTextBox = new TextBox();
            bottomPanel = new TableLayoutPanel();
            statsLabel = new Label();
            resultTitleLabel = new Label();
            resultValueLabel = new Label();
            statusLabel = new Label();
            mainLayoutPanel.SuspendLayout();
            topPanel.SuspendLayout();
            buttonPanel.SuspendLayout();
            promptGroupBox.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            mainLayoutPanel.ColumnCount = 1;
            mainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayoutPanel.Controls.Add(topPanel, 0, 0);
            mainLayoutPanel.Controls.Add(promptGroupBox, 0, 1);
            mainLayoutPanel.Controls.Add(bottomPanel, 0, 2);
            mainLayoutPanel.Dock = DockStyle.Fill;
            mainLayoutPanel.Location = new Point(0, 0);
            mainLayoutPanel.Name = "mainLayoutPanel";
            mainLayoutPanel.Padding = new Padding(13, 11, 13, 11);
            mainLayoutPanel.RowCount = 3;
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            mainLayoutPanel.Size = new Size(1100, 644);
            mainLayoutPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            topPanel.ColumnCount = 2;
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 132F));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            topPanel.Controls.Add(apiKeyLabel, 0, 0);
            topPanel.Controls.Add(apiKeyTextBox, 1, 0);
            topPanel.Controls.Add(modelLabel, 0, 1);
            topPanel.Controls.Add(modelComboBox, 1, 1);
            topPanel.Controls.Add(buttonPanel, 1, 2);
            topPanel.Dock = DockStyle.Fill;
            topPanel.Location = new Point(16, 14);
            topPanel.Name = "topPanel";
            topPanel.RowCount = 3;
            topPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            topPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            topPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            topPanel.Size = new Size(1068, 122);
            topPanel.TabIndex = 0;
            // 
            // apiKeyLabel
            // 
            apiKeyLabel.AutoSize = true;
            apiKeyLabel.Dock = DockStyle.Fill;
            apiKeyLabel.Location = new Point(3, 0);
            apiKeyLabel.Name = "apiKeyLabel";
            apiKeyLabel.Size = new Size(126, 37);
            apiKeyLabel.TabIndex = 0;
            apiKeyLabel.Text = "API Key";
            apiKeyLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // apiKeyTextBox
            // 
            apiKeyTextBox.Dock = DockStyle.Fill;
            apiKeyTextBox.Location = new Point(135, 4);
            apiKeyTextBox.Margin = new Padding(3, 4, 3, 4);
            apiKeyTextBox.Name = "apiKeyTextBox";
            apiKeyTextBox.PasswordChar = '*';
            apiKeyTextBox.PlaceholderText = "貼上 Gemini API Key";
            apiKeyTextBox.Size = new Size(930, 30);
            apiKeyTextBox.TabIndex = 1;
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Dock = DockStyle.Fill;
            modelLabel.Location = new Point(3, 37);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(126, 37);
            modelLabel.TabIndex = 2;
            modelLabel.Text = "Gemini 模型";
            modelLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modelComboBox
            // 
            modelComboBox.Dock = DockStyle.Left;
            modelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modelComboBox.FormattingEnabled = true;
            modelComboBox.Location = new Point(135, 41);
            modelComboBox.Margin = new Padding(3, 4, 3, 4);
            modelComboBox.Name = "modelComboBox";
            modelComboBox.Size = new Size(286, 31);
            modelComboBox.TabIndex = 3;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(countButton);
            buttonPanel.Controls.Add(clearButton);
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Location = new Point(135, 78);
            buttonPanel.Margin = new Padding(3, 4, 3, 4);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(0, 2, 0, 2);
            buttonPanel.Size = new Size(930, 40);
            buttonPanel.TabIndex = 4;
            // 
            // countButton
            // 
            countButton.Location = new Point(3, 5);
            countButton.Name = "countButton";
            countButton.Size = new Size(150, 36);
            countButton.TabIndex = 0;
            countButton.Text = "計算 Tokens";
            countButton.UseVisualStyleBackColor = true;
            countButton.Click += countButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(159, 5);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(110, 36);
            clearButton.TabIndex = 1;
            clearButton.Text = "清空";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // promptGroupBox
            // 
            promptGroupBox.Controls.Add(promptTextBox);
            promptGroupBox.Dock = DockStyle.Fill;
            promptGroupBox.Location = new Point(16, 142);
            promptGroupBox.Name = "promptGroupBox";
            promptGroupBox.Padding = new Padding(13, 11, 13, 11);
            promptGroupBox.Size = new Size(1068, 387);
            promptGroupBox.TabIndex = 1;
            promptGroupBox.TabStop = false;
            promptGroupBox.Text = "輸入文字";
            // 
            // promptTextBox
            // 
            promptTextBox.AcceptsReturn = true;
            promptTextBox.AcceptsTab = true;
            promptTextBox.Dock = DockStyle.Fill;
            promptTextBox.Location = new Point(13, 34);
            promptTextBox.Multiline = true;
            promptTextBox.Name = "promptTextBox";
            promptTextBox.PlaceholderText = "輸入要送去 Gemini 的文字，只做 token 計算，不做生成。";
            promptTextBox.ScrollBars = ScrollBars.Both;
            promptTextBox.Size = new Size(1042, 342);
            promptTextBox.TabIndex = 0;
            promptTextBox.TextChanged += promptTextBox_TextChanged;
            // 
            // bottomPanel
            // 
            bottomPanel.ColumnCount = 2;
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            bottomPanel.Controls.Add(statsLabel, 0, 0);
            bottomPanel.Controls.Add(resultTitleLabel, 0, 1);
            bottomPanel.Controls.Add(resultValueLabel, 1, 1);
            bottomPanel.Controls.Add(statusLabel, 0, 2);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(16, 535);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.RowCount = 3;
            bottomPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            bottomPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            bottomPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            bottomPanel.Size = new Size(1068, 95);
            bottomPanel.TabIndex = 2;
            // 
            // statsLabel
            // 
            statsLabel.AutoSize = true;
            bottomPanel.SetColumnSpan(statsLabel, 2);
            statsLabel.Dock = DockStyle.Fill;
            statsLabel.Location = new Point(3, 0);
            statsLabel.Name = "statsLabel";
            statsLabel.Size = new Size(1062, 28);
            statsLabel.TabIndex = 0;
            statsLabel.Text = "字元數：0    行數：0";
            statsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resultTitleLabel
            // 
            resultTitleLabel.AutoSize = true;
            resultTitleLabel.Dock = DockStyle.Fill;
            resultTitleLabel.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 136);
            resultTitleLabel.Location = new Point(3, 28);
            resultTitleLabel.Name = "resultTitleLabel";
            resultTitleLabel.Size = new Size(528, 37);
            resultTitleLabel.TabIndex = 1;
            resultTitleLabel.Text = "Token 數";
            resultTitleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resultValueLabel
            // 
            resultValueLabel.AutoSize = true;
            resultValueLabel.Dock = DockStyle.Fill;
            resultValueLabel.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 136);
            resultValueLabel.Location = new Point(537, 28);
            resultValueLabel.Name = "resultValueLabel";
            resultValueLabel.Size = new Size(528, 37);
            resultValueLabel.TabIndex = 2;
            resultValueLabel.Text = "-";
            resultValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            bottomPanel.SetColumnSpan(statusLabel, 2);
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Location = new Point(3, 65);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1062, 37);
            statusLabel.TabIndex = 3;
            statusLabel.Text = "待命中";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 644);
            Controls.Add(mainLayoutPanel);
            MinimumSize = new Size(988, 575);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gemini Token Counter";
            mainLayoutPanel.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            buttonPanel.ResumeLayout(false);
            promptGroupBox.ResumeLayout(false);
            promptGroupBox.PerformLayout();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayoutPanel;
        private TableLayoutPanel topPanel;
        private Label apiKeyLabel;
        private TextBox apiKeyTextBox;
        private Label modelLabel;
        private ComboBox modelComboBox;
        private FlowLayoutPanel buttonPanel;
        private Button countButton;
        private Button clearButton;
        private GroupBox promptGroupBox;
        private TextBox promptTextBox;
        private TableLayoutPanel bottomPanel;
        private Label statsLabel;
        private Label resultTitleLabel;
        private Label resultValueLabel;
        private Label statusLabel;
    }
}
