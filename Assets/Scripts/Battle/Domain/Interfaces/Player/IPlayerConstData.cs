namespace Battle.Domain.Interfaces.Player
{
    public interface IPlayerConstData
    {
        public float MoveSpeed { get; }
        
        public int PlayerMaxLife { get; }
    }
}