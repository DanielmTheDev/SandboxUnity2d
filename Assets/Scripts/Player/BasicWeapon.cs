using MageQueen;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("in trigger");
        var hittable = other.GetComponent<IHittable>();
        Debug.Log(hittable);
        hittable?.OnHit();
    }
}
