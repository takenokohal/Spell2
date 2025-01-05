using System.Collections.Generic;
using System.Linq;
using Takenokohal.Utility;

namespace SpellProject.Battle.Domain.Core.Player
{
    public class PlayerDeck : IInitializeCheckable
    {
        private readonly List<SpellEntity> _currentDeck = new();

        private IEnumerable<SpellEntity> _originDeck;

        public void Init(IEnumerable<SpellEntity> originDeck)
        {
            _originDeck = originDeck;
            Reset();
            IsInitialized = true;
        }

        public void Draw(out SpellEntity value)
        {
            var nextSpell = _currentDeck.Last();
            value = nextSpell;

            _currentDeck.Remove(nextSpell);

            if (_currentDeck.Count > 0)
                return;

            Reset();
        }

        public void Reset()
        {
            _currentDeck.Clear();
            _currentDeck.AddRange(_originDeck);
        }

        public bool IsInitialized { get; private set; }
    }
}