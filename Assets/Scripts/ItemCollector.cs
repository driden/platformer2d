using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{

    private int pumpkins = 0;

    public bool CollectedFire = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "FireCapsule")
        {
            OnUnlockFire.Invoke();
            this.CollectedFire = true;
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "Pumpkins")
        {
            Destroy(collider.gameObject);
            pumpkins++;
            Debug.Log("pumpkins: " + pumpkins);
          //  fruitCounterText.text = ITEM_COUNT_TXT + fruits;
        }  

    }

    public UnityEvent OnUnlockFire;
}
