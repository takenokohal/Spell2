using R3;
using Takenokohal.Utility;

namespace SpellProject.Battle.Domain.Core.Player
{
    public class PlayerParameters : IInitializeCheckable
    {
        private readonly ReactiveProperty<int> _currentLife = new();
        public Observable<int> CurrentLifeObservable => _currentLife;

        public int CurrentLife
        {
            get => _currentLife.Value;
            set => _currentLife.Value = value;
        }

        public bool IsInitialized { get; private set; }

        public void Init(int maxLife)
        {
            CurrentLife = maxLife;

            IsInitialized = true;
        }
    }
}