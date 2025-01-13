using Fusion;
using R3;
using SpellProject.Battle.Domain.Core.Player;
using Takenokohal.Utility;

namespace SpellProject.Battle.Network
{
    public class NetworkedPlayerParameterBridge : NetworkBehaviour, IInitializeCheckable
    {
        [Networked, OnChangedRender(nameof(OnOtherPlayerLifeChanged))]
        public byte NetworkedPlayerLife { get; set; } 

        private PlayerParameters _playerParameters;

        private void OnOtherPlayerLifeChanged()
        {
            if(!IsInitialized)
                return;
            if(HasStateAuthority)
                return;
            _playerParameters.CurrentLife = NetworkedPlayerLife;
        }

        public void Construct(PlayerParameters playerParameters)
        {
            _playerParameters = playerParameters;
            Initialize();
        }

        private void Initialize()
        {
            if (HasStateAuthority)
            {
                _playerParameters.CurrentLifeObservable.Subscribe(value => NetworkedPlayerLife = (byte)value)
                    .AddTo(this);
            }

            IsInitialized = true;
        }

        public bool IsInitialized { get; private set; }
    }
}