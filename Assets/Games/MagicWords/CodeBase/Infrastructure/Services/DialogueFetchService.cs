using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Games.MagicWords.CodeBase.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public class DialogueFetchService : IDialogueFetchService
  {
    private const string GetDialogueDataEndpoint = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";
    public Dictionary<string, AvatarData> NameByAvatarData { get; } = new();
    public List<DialogueEntry> Dialogues { get; private set; } = new();
    

    public async UniTask FetchDialogueDataAsync()
    {
      using (UnityWebRequest request = UnityWebRequest.Get(GetDialogueDataEndpoint))
      {
        await request.SendWebRequest().ToUniTask();

        if (request.result != UnityWebRequest.Result.Success)
        {
          Debug.LogError($"[DialogueFetchService] Failed to fetch data: {request.error}");
          return;
        }
        
        try
        {
          DialogueData data = JsonUtility.FromJson<DialogueData>(request.downloadHandler.text);

          if (data == null || data.dialogue == null || data.avatars == null)
          {
            Debug.LogError("[DialogueFetchService] Invalid or missing data in response.");
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
                Debug.LogError($"[DialogueFetchService] Avatar couldn't be loaded: {e.Message}");
              }
            }
          }
        }
        catch (Exception e)
        {
          Debug.LogError($"[DialogueFetchService] JSON parsing error: {e.Message}");
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

        Debug.LogWarning($"[DialogueFetchService] Failed to load avatar from {url}: {request.error}");
        return null;
      }
    }
    
  }
}