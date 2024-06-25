using MageQueen;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var hittable = other.GetComponent<IHittable>();
        hittable?.OnHit();
    }
}
