using Common.Services;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public interface IEmojiTranslaterService : IService
  {
    string ReplaceEmojis(string text);
  }
}