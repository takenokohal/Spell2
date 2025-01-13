using UnityEngine;

namespace SpellProject.Battle.Domain.Core.Player
{
    public class PlayerFacade
    {
        public PlayerFacade(PlayerBody playerBody, PlayerKey playerKey, PlayerParameters playerParameters)
        {
            PlayerBody = playerBody;
            PlayerKey = playerKey;
            PlayerParameters = playerParameters;
        }

        public PlayerBody PlayerBody { get; }

        public PlayerKey PlayerKey { get; }

        public PlayerParameters PlayerParameters { get; }

        public Vector2 GetDirectionToPlayer(Vector2 from)
        {
            return (PlayerBody.Position - from).normalized;
        }
    }
}