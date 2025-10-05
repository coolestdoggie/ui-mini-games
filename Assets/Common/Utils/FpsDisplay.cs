using TMPro;
using UnityEngine;

namespace Common.Utils
{
    public class FpsDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fpsText;
        private float _deltaTime = 0.0f;

        void Update()
        {
            _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
            float fps = 1.0f / _deltaTime;
            _fpsText.text = "FPS: " + Mathf.Round(fps);
        }
    }
}
