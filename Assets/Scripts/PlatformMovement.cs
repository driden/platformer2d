using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] movementPath;
    private int currentPathIndex = 0;
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(movementPath[currentPathIndex].transform.position, transform.position) < .1f)
        {
            currentPathIndex ++;
            if (currentPathIndex >= movementPath.Length)
            {
                currentPathIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, movementPath[currentPathIndex].transform.position, 
        Time.deltaTime * speed);
    }
}
