using UnityEngine;
using UnityEngine.UI;

namespace Games.LoadingMenu.CodeBase.UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button _aceOfShadowsGameButton;
        [SerializeField] private Button _magicWordsGameButton;
        [SerializeField] private Button _phoenixFlameGameButton;

        public Button AceOfShadowsGameButton => _aceOfShadowsGameButton;
        public Button MagicWordsGameButton => _magicWordsGameButton;
        public Button PhoenixFlameGameButton => _phoenixFlameGameButton;
    }
}
