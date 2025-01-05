using R3;

namespace SpellProject.Battle.Domain.Interfaces.Player
{
    public interface IPlayerParameters
    {
        public float PlayerLife { get; set; }
        public Observable<float> PlayerLifeObservable { get; }
    }
}