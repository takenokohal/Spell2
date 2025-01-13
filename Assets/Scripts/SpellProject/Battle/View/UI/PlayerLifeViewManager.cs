using UnityEngine;

namespace SpellProject.Battle.View.UI
{
    public class PlayerLifeViewManager : MonoBehaviour
    {
        [SerializeField] private PlayerLifeUIView[] playerLifeUIViews;
        
        public PlayerLifeUIView[] PlayerLifeUIViews => playerLifeUIViews;
    }
}