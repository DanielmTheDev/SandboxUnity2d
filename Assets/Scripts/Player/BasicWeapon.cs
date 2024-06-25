using MageQueen;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in trigger");
        var hittable = other.GetComponent<IHittable>();
        Debug.Log(hittable);
        hittable?.OnHit();
    }
}
