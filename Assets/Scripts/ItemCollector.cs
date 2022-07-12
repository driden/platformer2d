using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    
    public SFXManager sfx;

    [SerializeField] private TextMeshProUGUI itemCounterText;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("FireCapsule"))
        {
            OnUnlockFire.Invoke();
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Pumpkins"))
        {
            Destroy(collider.gameObject);
            Pumpkins.AddPumpkin();
            itemCounterText.text = "Points: " + Pumpkins.GetPumpkins();
            sfx.playPickUp();
        }
        else if (collider.gameObject.CompareTag("SpeedUp"))
        {
            OnUnlockSpeedUp.Invoke();
            Destroy(collider.gameObject);
        }
    }

    public UnityEvent OnUnlockFire;
    public UnityEvent OnUnlockSpeedUp;
}
