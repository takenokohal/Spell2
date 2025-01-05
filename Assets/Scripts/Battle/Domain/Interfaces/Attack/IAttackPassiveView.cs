using Battle.Domain.Core.Attack;

namespace Battle.Domain.Interfaces.Attack
{
    public interface IAttackPassiveView
    {
        public void OnAttacked(AttackParameter attackParameter);
    }
}