using Fusion;

namespace SpellProject.Battle.Network
{
    public class NetworkedPlayerHandPresenter : NetworkBehaviour
    {
        [Networked, Capacity(4)]  NetworkArray<byte> NetworkedHand { get; }
        public void SetValue(int index, byte value) => NetworkedHand.Set(index, value);
    }
}