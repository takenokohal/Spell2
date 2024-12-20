using System;
using Battle.Model.BattleObject.Bullet;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;

namespace Battle.Model.Spell.Variable
{
    public class TestSpell : SpellBase
    {
        private class AdditionalData : ISpellAdditionalData
        {
            public string BulletKey;
        }

        public override UniTask Sequence()
        {
            return UniTask.CompletedTask;

        }
    }
}