using Common.Services;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public interface IEmojiTranslaterService : IService
  {
    string ReplaceEmojis(string text);
  }
}