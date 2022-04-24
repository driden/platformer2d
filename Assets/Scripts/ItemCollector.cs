using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public bool CollectedFire = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "FireCapsule")
        {
            this.CollectedFire = true;
            Destroy(collider.gameObject);
        }
    }
}
