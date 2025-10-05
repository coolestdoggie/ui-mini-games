using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MagicWords.CodeBase.UI
{
  public class DialogEntryView : MonoBehaviour
  {
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _avatar;
    [SerializeField] private TMP_Text _message;
    [SerializeField] private HorizontalLayoutGroup _horizontalLayoutGroup;

    public void SetName(string name)
    {
      _name.text = name;
    }
  
    public void SetAvatar(Sprite sprite)
    {
      if (sprite == null)
      {
        Debug.LogWarning("[DialogEntryView] Attempt to assign Avatar as null, ignoring");
        return;
      }
    
      _avatar.sprite = sprite;
    }

    public void SetMessage(string message) => 
      _message.text = message;

    public void SetPositioningRightSide(bool right) =>
      _horizontalLayoutGroup.reverseArrangement = right;
  }
}
