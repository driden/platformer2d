using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform characterMovement;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name.Equals("Stairs")) Debug.Log("coll");
    }
}
