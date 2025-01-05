using Fusion;

namespace Battle.Network
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