using UnityEngine;

namespace MageQueen
{
    public class MageQueenController : MonoBehaviour, IHittable
    {
        public Animator animator;
        private static readonly int GetHit = Animator.StringToHash("GetHit");

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void OnHit()
        {
            animator.SetTrigger(GetHit);
        }
    }
}
