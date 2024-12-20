﻿namespace Battle.Model.Player
{
    public class PlayerFacade
    {
        public PlayerFacade(PlayerBody playerBody, PlayerKey playerKey)
        {
            PlayerBody = playerBody;
            PlayerKey = playerKey;
        }

        public PlayerBody PlayerBody { get; }

        public PlayerKey PlayerKey { get; }
    }
}