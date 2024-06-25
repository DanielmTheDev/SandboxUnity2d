using UnityEngine;

namespace MageQueen
{
    public class MageQueenController : MonoBehaviour, IHittable
    {
        public Animator animator;
        private CooldownExecutor _getHitExecutor;

        private static readonly int GetHit = Animator.StringToHash("GetHit");

        private void Start()
        {
            animator = GetComponent<Animator>();
            _getHitExecutor = new(1, () => animator.SetTrigger(GetHit));
        }

        public void OnHit() => _getHitExecutor.Execute();
    }
}
