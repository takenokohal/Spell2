using System;
using SpellProject.Battle.Domain.Core.Player;
using UnityEngine;

namespace SpellProject.Battle.Domain.BaseRules.MagicCircles
{
    public class MagicCircleParameter
    {
        public PlayerFacade OwnerFacade { get; }
        public float Size { get; }
        public Func<Vector2> Position { get; }

        public MagicCircleParameter(PlayerFacade ownerFacade, float size, Func<Vector2> position)
        {
            OwnerFacade = ownerFacade;
            Size = size;
            Position = position;
        }
    }
}