using System;
using UnityEngine;

namespace Games.MagicWords.CodeBase.Data
{
  [Serializable]
  public class DialogueData
  {
    public DialogueEntry[] dialogue;
    public AvatarData[] avatars;
  }

  [Serializable]
  public class DialogueEntry
  {
    public string name;
    public string text;
  }

  [Serializable]
  public class AvatarData
  {
    public string name;
    public string url;
    public string position; // "left" or "right"
    
    [NonSerialized] public Sprite sprite;
    public bool PositionedRight => position == "right" ;
  }
}