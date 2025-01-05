using Fusion;

namespace SpellProject.Battle.Network
{
    //Injectもされないしコンストラクタも呼べないので、むりやりFind
    public class PlayerSpawnCall : NetworkBehaviour
    {
        private void Start()
        {
            IPlayerBinder.Find().Bind(this, HasStateAuthority);
        }
    }
}