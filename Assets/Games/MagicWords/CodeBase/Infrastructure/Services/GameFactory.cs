using Games.MagicWords.CodeBase.UI;
using UnityEngine;

namespace Games.MagicWords.CodeBase.Infrastructure.Services
{
  public class GameFactory : IGameFactory
  {
    private const string UIRootPath = "MagicWords/UIRoot";
    private const string DialogueEntry = "MagicWords/DialogueEntry";
    public Transform UiRoot { get; private set; }
    public Transform ContentRoot { get; private set; }

    public void CreateUIRoot()
    {
      GameObject rootPrefab = Resources.Load<GameObject>(UIRootPath);
      GameObject root = Object.Instantiate(rootPrefab);
      
      UiRoot = root.transform;
      ContentRoot = root.GetComponent<UIRoot>().ContentRoot;
    }

    public DialogEntryView CreateDialogueEntry()
    {
      GameObject dialogueEntryPrefab = Resources.Load<GameObject>(DialogueEntry);
      GameObject dialogueEntry = Object.Instantiate(dialogueEntryPrefab, ContentRoot, true);
      return dialogueEntry.GetComponent<DialogEntryView>();
    }
    
  }
}