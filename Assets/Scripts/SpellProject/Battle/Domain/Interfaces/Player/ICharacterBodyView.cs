using UnityEngine;

namespace SpellProject.Battle.Domain.Interfaces.Player
{
    public interface ICharacterBodyView
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Rotation { get; set; }
    }
}