using SpellProject.Battle.Domain.Core.Attack;

namespace SpellProject.Battle.Domain.Interfaces.Attack
{
    public interface IAttackPassiveView
    {
        public void OnAttacked(AttackParameter attackParameter);
    }
}