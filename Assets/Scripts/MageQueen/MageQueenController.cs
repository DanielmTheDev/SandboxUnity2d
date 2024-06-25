using UnityEngine;

namespace MageQueen
{
    public class MageQueenController : MonoBehaviour, IHittable
    {
        public void OnHit()
        {
            Debug.Log("HIT");
        }
    }
}
