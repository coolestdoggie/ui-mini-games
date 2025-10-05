using UnityEngine;

namespace AceOfShadows.CodeBase.DecksConfig
{
    [CreateAssetMenu(fileName = "DecksConfig", menuName = "Configs/DecksConfig")]
    public class DecksConfig : ScriptableObject
    {
        [SerializeField] private float _deckYOffset = 12f;
        [SerializeField] private int _realCardsThreshold = 10;
        [SerializeField] private int _initialCardsAmount = 144;

        public float DeckYOffset => _deckYOffset;
        public int RealCardsThreshold => _realCardsThreshold;
        public int InitialCardsAmount => _initialCardsAmount;
    }
}