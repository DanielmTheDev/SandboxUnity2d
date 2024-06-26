using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.U2D.IK;

namespace MageQueen
{
    [RequireComponent(typeof(IKManager2D))]
    [RequireComponent(typeof(Animator))]
    public class MageQueenController : MonoBehaviour, IHittable
    {
        public Transform crossHair;
        public Transform playerCharacter;

        // Crosshair movement parameters
        public float crosshairRadius = 20f;
        public float crosshairSpeed = 90f; // degrees per second

        private Animator _animator;

        private CooldownExecutor _getHitExecutor;
        private static readonly int GetHit = Animator.StringToHash("GetHit");

        // Crosshair movement control
        private bool _isMovingCrosshair;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _getHitExecutor = new(1, () => _animator.SetTrigger(GetHit));
            StartCoroutine(AttackSequence());
        }

        private void Update()
        {
            if (_isMovingCrosshair)
            {
                MoveCrosshair();
            }
        }

        private void MoveCrosshair()
        {
            var directionToPlayer = (playerCharacter.position - transform.position).normalized;
            var currentAngle = Vector3.SignedAngle(Vector3.right, crossHair.position - transform.position, Vector3.forward);
            var targetAngle = Vector3.SignedAngle(Vector3.right, directionToPlayer, Vector3.forward);
            var newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, crosshairSpeed * Time.deltaTime);
            var newPosition = transform.position + Quaternion.Euler(0, 0, newAngle) * (Vector3.right * crosshairRadius);
            crossHair.position = newPosition;
        }

        private IEnumerator AttackSequence()
        {
            while (true)
            {
                crossHair.gameObject.SetActive(true);
                _isMovingCrosshair = true;

                yield return new WaitForSeconds(3f);

                _isMovingCrosshair = false;
                yield return new WaitForSeconds(1f);

                // Shoot projectile
                ShootProjectile();

                crossHair.gameObject.SetActive(false);

                yield return new WaitForSeconds(2f);
            }
            // ReSharper disable once IteratorNeverReturns
        }

        private void ShootProjectile()
        {
            // Implement your projectile shooting logic here
            Debug.Log("Shooting projectile at " + crossHair.position);
            // Example: Instantiate a projectile prefab at the crosshair position
            // GameObject projectile = Instantiate(projectilePrefab, crossHair.position, Quaternion.identity);
            // projectile.GetComponent<Rigidbody2D>().velocity = (playerCharacter.position - crossHair.position).normalized * projectileSpeed;
        }

        public void OnHit() => _getHitExecutor.Execute();
    }
}