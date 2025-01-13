using SpellProject.Battle.Domain.Core;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.God;
using UnityEngine;
using VContainer;

namespace SpellProject.Battle.Infrastructure
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