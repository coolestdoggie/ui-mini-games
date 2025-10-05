using UnityEngine;
using UnityEngine.UI;

namespace Games.PhoenixFlame.CodeBase.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Button _changeFireColorButton;

        public Button ChangeFireColorButton => _changeFireColorButton;
    }
}
