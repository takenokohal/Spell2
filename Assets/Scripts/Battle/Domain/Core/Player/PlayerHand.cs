using System.Collections.Generic;
using Battle.Domain.Interfaces;
using ObservableCollections;

namespace Battle.Domain.Core.Player
{
    public class PlayerHand : IInitializeCheckable
    {
        private readonly ObservableList<SpellEntity> _currentHand = new();
        public IReadOnlyObservableList<SpellEntity> CurrentHand => _currentHand;
        public bool IsInitialized { get; private set; }

        public void Initialize(IEnumerable<SpellEntity> firstHand)
        {
            _currentHand.AddRange(firstHand);
            IsInitialized = true;
        }

        public void Change(int index, SpellEntity nextSpell)
        {
            _currentHand[index] = nextSpell;
        }
    }
}