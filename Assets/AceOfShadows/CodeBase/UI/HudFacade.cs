using TMPro;
using UnityEngine;

namespace AceOfShadows.CodeBase.UI
{
    public class HudFacade : MonoBehaviour
    {
        [SerializeField] private RectTransform _leftDeckTransform;
        [SerializeField] private RectTransform _rightDeckTransform;
        [SerializeField] private TMP_Text _leftDeckCounter;
        [SerializeField] private TMP_Text _rightDeckCounter;
        [SerializeField] private GameObject _theEndLabel;

        public RectTransform LeftDeckTransform => _leftDeckTransform;
        public RectTransform RightDeckTransform => _rightDeckTransform;

        public void UpdateLeftDeckCounter(int count) =>
            _leftDeckCounter.text = count.ToString();

        public void UpdateRightDeckCounter(int count) =>
            _rightDeckCounter.text = count.ToString();

        public void SetActiveEndLabel(bool active) =>
            _theEndLabel.SetActive(active);
    }
}
