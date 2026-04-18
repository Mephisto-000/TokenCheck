using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TokenCheckApp.Services;

public sealed class GeminiTokenCountService
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://generativelanguage.googleapis.com/")
    };

    public async Task<int> CountTokensAsync(string apiKey, string model, string text, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new ArgumentException("請輸入 API Key。", nameof(apiKey));
        }

        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("請選擇 Gemini 模型。", nameof(model));
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        var request = new CountTokensRequest
        {
            Contents =
            [
                new Content
                {
                    Parts =
                    [
                        new Part
                        {
                            Text = text
                        }
                    ]
                }
            ]
        };

        var requestUri = $"v1beta/models/{Uri.EscapeDataString(model)}:countTokens?key={Uri.EscapeDataString(apiKey)}";
        using var response = await HttpClient.PostAsJsonAsync(requestUri, request, cancellationToken);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Gemini token 計算失敗：{(int)response.StatusCode} {response.ReasonPhrase}{Environment.NewLine}{responseBody}");
        }

        var result = JsonSerializer.Deserialize<CountTokensResponse>(responseBody);
        return result?.TotalTokens ?? 0;
    }

    private sealed class CountTokensRequest
    {
        [JsonPropertyName("contents")]
        public List<Content> Contents { get; set; } = [];
    }

    private sealed class Content
    {
        [JsonPropertyName("parts")]
        public List<Part> Parts { get; set; } = [];
    }

    private sealed class Part
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }

    private sealed class CountTokensResponse
    {
        [JsonPropertyName("totalTokens")]
        public int TotalTokens { get; set; }
    }
}
