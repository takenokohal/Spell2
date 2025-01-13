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
    }
}