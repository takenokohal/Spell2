using R3;
using SpellProject.Battle.Detail.ConstData;
using SpellProject.Battle.Domain.Interfaces.Player;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace SpellProject.Battle.View.UI
{
    public class PlayerLifeUIView : MonoBehaviour
    {
        [SerializeField] private Slider sliderTest;
        [Inject] private readonly PlayerConstData _playerConstData;
        [Inject] private readonly IPlayerParameters _playerParameters;


        private void Start()
        {
            _playerParameters.PlayerLifeObservable.Subscribe(value =>
                sliderTest.value = value / _playerConstData.PlayerMaxLife).AddTo(this);
        }
    }
}