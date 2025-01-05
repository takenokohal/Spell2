using UnityEngine;

namespace Takenokohal.Utility
{
    public static class Vector2Extension
    {
        public static Vector2 RadianToVector(float rad)
        {
            return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }

        public static Vector2 AngleToVector(float angle)
        {
            return RadianToVector(angle * Mathf.Deg2Rad);
        }
    }
}