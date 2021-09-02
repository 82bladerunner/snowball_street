using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
