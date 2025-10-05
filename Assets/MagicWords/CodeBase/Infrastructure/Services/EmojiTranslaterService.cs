using System.Collections.Generic;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public class EmojiTranslaterService : IEmojiTranslaterService
  {
    private readonly Dictionary<string, string> emojiMap = new()
    {
      {"satisfied", "😊"},
      {"intrigued", "😋"},
      {"neutral", "😉"},
      {"affirmative", "😁"},
      {"laughing", "😂"},
      {"win", "😎"}
    };
    
    public string ReplaceEmojis(string text)
    {
      if (string.IsNullOrEmpty(text)) return text;

      foreach (var kvp in emojiMap)
      {
        text = text.Replace("{" + kvp.Key + "}", kvp.Value);
      }
      return text;
    }
  }
}