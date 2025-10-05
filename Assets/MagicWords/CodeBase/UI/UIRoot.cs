using UnityEngine;

namespace MagicWords.CodeBase.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private RectTransform _contentRoot;

        public RectTransform ContentRoot => _contentRoot;
    }
}
