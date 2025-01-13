using R3;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;
using UnityEngine.UI;

namespace SpellProject.Battle.View.UI
{
    public class PlayerLifeUIView : MonoBehaviour
    {
        [SerializeField] private Slider sliderTest;
        private IBattleConstDataProvider _battleConstDataProvider;
        private PlayerParameters _playerParameters;


        public void Construct(IBattleConstDataProvider battleConstDataProvider, PlayerParameters playerParameters)
        {
            _battleConstDataProvider = battleConstDataProvider;
            _playerParameters = playerParameters;

            Init();
        }

        private void Init()
        {
            _playerParameters.CurrentLifeObservable.Subscribe(value =>
            {
                sliderTest.value = (float)value / _battleConstDataProvider.GetBattleConstData().PlayerMaxLife;
            }).AddTo(this);
        }
    }
}