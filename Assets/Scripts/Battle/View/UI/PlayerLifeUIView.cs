using Battle.Domain.Interfaces.Player;
using Data.Database;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Battle.View.UI
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