using Battle.Domain.Interfaces.Player;
using Fusion;
using Fusion.Editor;
using R3;

namespace Battle.Network
{
    public class NetworkedPlayerParameter : NetworkBehaviour, IPlayerParameters
    {
        [Networked, OnChangedRender(nameof(CallPlayerLifeEvent))]
        public float PlayerLife { get; set; } = 100;

        private readonly Subject<float> _playerLifeEvent = new();
        private void CallPlayerLifeEvent(float value) => _playerLifeEvent.OnNext(value);
        public Observable<float> PlayerLifeObservable => _playerLifeEvent;
    }
}