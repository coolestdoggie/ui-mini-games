using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MagicWords.CodeBase.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace MagicWords.CodeBase.Infrastructure.Services
{
  public class DialogueFetchService : IDialogueFetchService
  {
    public Dictionary<string, AvatarData> NameByAvatarData { get; } = new();
    public List<DialogueEntry> Dialogues { get; private set; } = new();
    

    public async UniTask FetchDialogueDataAsync()
    {
      using (UnityWebRequest request = UnityWebRequest.Get("https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords"))
      {
        var operation = await request.SendWebRequest().ToUniTask();

        if (request.result != UnityWebRequest.Result.Success)
        {
          Debug.LogError($"Failed to fetch data: {request.error}");
          return;
        }
        try
        {
          DialogueData data = JsonUtility.FromJson<DialogueData>(request.downloadHandler.text);

          if (data == null || data.dialogue == null || data.avatars == null)
          {
            Debug.LogError("Invalid or missing data in response.");
            return;
          }

          Dialogues = data.dialogue.ToList();
          
          NameByAvatarData.Clear();
          foreach (var avatar in data.avatars)
          {
            if (!string.IsNullOrEmpty(avatar.name) && !string.IsNullOrEmpty(avatar.url))
            {
              NameByAvatarData[avatar.name] = avatar;
              try
              {
                avatar.sprite = await LoadAvatarSpriteAsync(avatar.url);
              }
              catch (Exception e)
              {
                Debug.LogError($"Avatar couldn't be loaded: {e.Message}");
              }
            }
          }
        }
        catch (Exception e)
        {
          Debug.LogError($"JSON parsing error: {e.Message}");
        }
      }
    }
    
    private async UniTask<Sprite> LoadAvatarSpriteAsync(string url)
    {
      using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
      {
        await request.SendWebRequest().ToUniTask();

        if (request.result == UnityWebRequest.Result.Success)
        {
          Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
          return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one * 0.5f);
        }

        Debug.LogWarning($"Failed to load avatar from {url}: {request.error}");
        return null;
      }
    }
    
  }
}