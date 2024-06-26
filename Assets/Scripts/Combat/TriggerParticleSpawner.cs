using UnityEngine;

namespace Combat
{
    public class TriggerParticleSpawner : MonoBehaviour
    {
        public GameObject particleEffectPrefab;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("World"))
                return;
            var collisionPoint = other.ClosestPoint(transform.position);
            var particleEffect = Instantiate(particleEffectPrefab, collisionPoint, Quaternion.identity);
            Destroy(particleEffect, 2f);
            Destroy(gameObject);
        }
    }
}