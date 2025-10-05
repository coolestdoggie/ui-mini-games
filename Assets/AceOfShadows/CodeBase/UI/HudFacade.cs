using TMPro;
using UnityEngine;

public class HudFacade : MonoBehaviour
{
    [SerializeField] private RectTransform _leftDeckTransform;
    [SerializeField] private RectTransform _rightDeckTransform;
    [SerializeField] private TMP_Text _leftDeckCounter;
    [SerializeField] private TMP_Text _rightDeckCounter;

    public RectTransform LeftDeckTransform => _leftDeckTransform;
    public RectTransform RightDeckTransform => _rightDeckTransform;

    public void UpdateLeftDeckCounter(int count) =>
        _leftDeckCounter.text = count.ToString();

    public void UpdateRightDeckCounter(int count) =>
        _rightDeckCounter.text = count.ToString();}
