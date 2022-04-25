using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    public bool CollectedFire = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "FireCapsule")
        {
            OnUnlockFire.Invoke();
            this.CollectedFire = true;
            Destroy(collider.gameObject);
        }
    }

    public UnityEvent OnUnlockFire;
}
