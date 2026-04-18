using TokenCheckApp.Services;

namespace TokenCheckApp;

public partial class Form1 : Form
{
    private readonly GeminiTokenCountService geminiTokenCountService = new();

    public Form1()
    {
        InitializeComponent();
        InitializeModels();
        UpdateStats();
    }

    private void InitializeModels()
    {
        modelComboBox.Items.AddRange(
        [
            "gemini-2.5-pro",
            "gemini-2.5-flash",
            "gemini-2.0-flash",
            "gemini-2.0-flash-lite",
            "gemini-1.5-pro",
            "gemini-1.5-flash",
            "gemini-1.5-flash-8b"
        ]);

        modelComboBox.SelectedIndex = 0;
    }

    private void promptTextBox_TextChanged(object sender, EventArgs e)
    {
        UpdateStats();
    }

    private async void countButton_Click(object sender, EventArgs e)
    {
        try
        {
            ToggleUi(false);
            resultValueLabel.Text = "-";
            statusLabel.Text = "計算中...";

            var tokenCount = await geminiTokenCountService.CountTokensAsync(
                apiKeyTextBox.Text.Trim(),
                modelComboBox.SelectedItem?.ToString() ?? string.Empty,
                promptTextBox.Text);

            resultValueLabel.Text = tokenCount.ToString("N0");
            statusLabel.Text = "完成";
        }
        catch (Exception ex)
        {
            resultValueLabel.Text = "-";
            statusLabel.Text = "失敗";
            MessageBox.Show(this, ex.Message, "Gemini Token Counter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            ToggleUi(true);
        }
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        promptTextBox.Clear();
        resultValueLabel.Text = "-";
        statusLabel.Text = "已清空";
    }

    private void UpdateStats()
    {
        var text = promptTextBox.Text;
        var charCount = text.Length;
        var lineCount = string.IsNullOrEmpty(text)
            ? 0
            : text.Replace("\r\n", "\n").Split('\n').Length;

        statsLabel.Text = $"字元數：{charCount:N0}    行數：{lineCount:N0}";
    }

    private void ToggleUi(bool enabled)
    {
        apiKeyTextBox.Enabled = enabled;
        modelComboBox.Enabled = enabled;
        promptTextBox.Enabled = enabled;
        countButton.Enabled = enabled;
        clearButton.Enabled = enabled;
    }
}
