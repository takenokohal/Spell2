using Cysharp.Threading.Tasks;

namespace SpellProject.Battle.Domain.BaseRules.MagicCircles
{
    public interface IMagicCircleFactory
    {
        public UniTask CreateAndWait(MagicCircleParameter magicCircleParameter);
    }
}