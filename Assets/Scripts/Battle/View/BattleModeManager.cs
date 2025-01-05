using Battle.Domain.Interfaces;
using Battle.God;
using Battle.Network;
using UnityEngine;
using VContainer;

namespace Battle.View
{
    public class BattleModeManager : MonoBehaviour, IBattleModeManager
    {
        [Inject] private readonly BattleParameterBridge _battleParameterBridge;
        [SerializeField] private BattleMode serializedBattleMode;

        public BattleMode BattleMode { get; private set; }

        private void Start()
        {
            BattleMode = _battleParameterBridge.BattleMode ?? serializedBattleMode;
            IsInitialized = true;
        }

        public bool IsInitialized { get; private set; }
    }
}