using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    private string ITEM_COUNT_TXT = "COLLECTED FRUITS: ";
    [SerializeField] private Text fruitCounterText;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Fruits")) 
        {
            Destroy(collision.gameObject);
            fruits++;
            fruitCounterText.text = ITEM_COUNT_TXT + fruits;
        }  
    }

}
