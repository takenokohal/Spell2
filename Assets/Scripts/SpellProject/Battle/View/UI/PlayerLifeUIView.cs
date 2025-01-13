using R3;
using SpellProject.Battle.Domain.Core.Player;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;
using UnityEngine.UI;

namespace SpellProject.Battle.View.UI
{
    public class PlayerLifeUIView : MonoBehaviour
    {
        [SerializeField] private Slider sliderTest;
        private IPlayerConstData _playerConstData;
        private PlayerParameters _playerParameters;


        public void Construct(IPlayerConstData playerConstData, PlayerParameters playerParameters)
        {
            _playerConstData = playerConstData;
            _playerParameters = playerParameters;

            Init();
        }

        private void Init()
        {
            _playerParameters.CurrentLifeObservable.Subscribe(value =>
            {
                sliderTest.value = (float)value / _playerConstData.PlayerMaxLife;
            }).AddTo(this);
        }
    }
}