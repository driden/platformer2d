using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    private int pumpkins = 0;
    [SerializeField] private TextMeshProUGUI itemCounterText;
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
            itemCounterText.text = "Points: " + pumpkins;
        }  

    }

    public UnityEvent OnUnlockFire;
}
