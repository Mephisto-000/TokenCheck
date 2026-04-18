# Gemini Token Counter

一個 Windows 桌面小工具，讓你在送出文字給 Gemini API 之前，先精確計算實際會消耗的 Token 數量。

---

## 功能簡介

- 輸入任意文字（中文、英文、程式碼等皆可）
- 選擇 Gemini 模型
- 透過 Gemini API 的 `countTokens` 端點取得**精確的 Token 數量**
- 即時顯示字元數與行數
- 不會產生任何內容生成，**不會消耗生成額度**

---

## Token 計算原理

### 什麼是 Token？

Token 是大型語言模型（LLM）處理文字時的最小單位。模型不是一個字一個字讀，而是把文字切成一段一段的 Token 再進行處理。

例如：

- 英文單字 `hello` 通常是 1 個 Token
- 中文字 `你好嗎` 可能被切成 2～3 個 Token
- 程式碼、特殊符號的切法又不同

不同廠商、不同模型使用的 Tokenizer 演算法不同，因此**同一段文字在不同模型上的 Token 數量可能不一樣**。

### 本程式的計算方式

本程式**不是用估算或近似公式**來算 Token 數量，而是直接呼叫 Google 官方的 Gemini API `countTokens` 端點：

```
POST https://generativelanguage.googleapis.com/v1beta/models/{model}:countTokens
```

這個端點會使用該模型**實際的 Tokenizer** 來計算你輸入的文字，回傳精確的 Token 數量。

#### 請求格式

程式會將你輸入的文字包成以下 JSON 格式送出：

```json
{
  "contents": [
    {
      "parts": [
        {
          "text": "你輸入的文字內容"
        }
      ]
    }
  ]
}
```

#### 回應格式

API 會回傳：

```json
{
  "totalTokens": 42
}
```

程式直接讀取 `totalTokens` 欄位並顯示在畫面上。

#### 核心程式碼

以下是 `GeminiTokenCountService.cs` 中負責呼叫 `countTokens` 端點的完整實作：

```csharp
public sealed class GeminiTokenCountService
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://generativelanguage.googleapis.com/")
    };

    public async Task<int> CountTokensAsync(
        string apiKey, string model, string text,
        CancellationToken cancellationToken = default)
    {
        // 1. 組裝請求內容，格式遵循 Gemini API 的 Content/Part 結構
        var request = new CountTokensRequest
        {
            Contents =
            [
                new Content
                {
                    Parts =
                    [
                        new Part { Text = text }
                    ]
                }
            ]
        };

        // 2. 組合 API 網址，將模型名稱與 API Key 帶入
        //    端點格式：v1beta/models/{model}:countTokens?key={apiKey}
        var requestUri =
            $"v1beta/models/{Uri.EscapeDataString(model)}:countTokens?key={Uri.EscapeDataString(apiKey)}";

        // 3. 透過 HttpClient 發送 POST 請求，內容序列化為 JSON
        using var response = await HttpClient.PostAsJsonAsync(requestUri, request, cancellationToken);
        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

        // 4. 若 API 回傳非成功狀態碼，拋出例外並附上錯誤訊息
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(
                $"Gemini token 計算失敗：{(int)response.StatusCode} {response.ReasonPhrase}\n{responseBody}");
        }

        // 5. 反序列化回應 JSON，取出 totalTokens 欄位
        var result = JsonSerializer.Deserialize<CountTokensResponse>(responseBody);
        return result?.TotalTokens ?? 0;
    }
}
```

**流程摘要：**

1. 將使用者輸入的文字包進 `contents[].parts[].text` 結構
2. 組合 `v1beta/models/{model}:countTokens` 端點網址，帶上 API Key
3. 使用 `HttpClient.PostAsJsonAsync()` 發送 POST 請求
4. 檢查 HTTP 狀態碼，失敗時拋出包含 API 錯誤訊息的例外
5. 成功時從回應 JSON 解析出 `totalTokens` 並回傳

> 整個過程只有一次 HTTP 呼叫，不做任何內容生成，API 回傳的就是該模型 Tokenizer 算出的精確 Token 數量。

### 為什麼不用本地估算？

常見的估算方式（例如「英文 4 個字元 ≈ 1 Token」、「中文 1.5 個字元 ≈ 1 Token」）只能當作粗略參考。實際上：

- 每個模型使用的 Tokenizer 不同（例如 BPE、SentencePiece 等）
- 中文、日文、韓文等 CJK 字元的 Token 密度差異很大
- 程式碼、JSON、Markdown 等格式化文字的切法也不一樣

直接呼叫官方 API 是**最準確**的做法。

---

## 支援的 Gemini 模型

| 模型名稱 | 說明 |
|---|---|
| `gemini-2.5-pro` | 2.5 世代旗艦模型 |
| `gemini-2.5-flash` | 2.5 世代快速模型 |
| `gemini-2.0-flash` | 2.0 世代快速模型 |
| `gemini-2.0-flash-lite` | 2.0 世代輕量模型 |
| `gemini-1.5-pro` | 1.5 世代旗艦模型 |
| `gemini-1.5-flash` | 1.5 世代快速模型 |
| `gemini-1.5-flash-8b` | 1.5 世代超輕量模型 |

> 以上模型皆支援 Gemini Developer API 的 `countTokens` 端點。

---

## 使用方式

1. 前往 [Google AI Studio](https://aistudio.google.com/apikey) 取得 Gemini API Key
2. 開啟程式，在 **API Key** 欄位貼上你的 Key
3. 從下拉選單選擇要測試的 **Gemini 模型**
4. 在文字框中輸入或貼上你想計算的文字
5. 點擊 **計算 Tokens** 按鈕
6. 畫面下方會顯示精確的 Token 數量

> `countTokens` 端點只做 Token 計算，**不會產生任何內容生成**，一般情況下不會產生費用。

---

## 使用的技術與工具

| 項目 | 說明 |
|---|---|
| 框架 | .NET 10 |
| UI 技術 | Windows Forms |
| 程式語言 | C# |
| HTTP 用戶端 | `System.Net.Http.HttpClient` |
| JSON 序列化 | `System.Text.Json` |
| API | [Gemini Developer API](https://ai.google.dev/gemini-api/docs/tokens?lang=rest) `v1beta` `countTokens` 端點 |
| 開發工具 | Visual Studio 2022+ |

---

## 專案結構

```
TokenCheckApp/
├── Form1.cs                              # 主畫面邏輯
├── Form1.Designer.cs                     # 主畫面 UI 配置
├── Program.cs                            # 程式進入點
├── TokenCheckApp.csproj                  # 專案檔
├── Services/
│   └── GeminiTokenCountService.cs        # Gemini countTokens API 呼叫服務
└── Models/                               # 資料模型（預留）
```

---

## 注意事項

- API Key 請妥善保管，不要提交到版本控制
- `countTokens` 雖然不做生成，但仍受 API 配額限制
- 模型清單可能隨 Google 更新而變動，若出現 `404 Not Found` 錯誤，代表該模型已不再支援

---

## 授權

MIT License
