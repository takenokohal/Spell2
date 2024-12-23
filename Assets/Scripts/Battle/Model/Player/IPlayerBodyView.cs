using UnityEngine;

namespace Battle.Model.Player
{
    public interface IPlayerBodyView
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public bool Rotation { get; set; }
    }
}