namespace Battle.Model.Attack
{
    public interface IAttackView
    {
        public void SetUp(AttackParameter attackParameter);
        public void Activate(bool isActive);
    }
}