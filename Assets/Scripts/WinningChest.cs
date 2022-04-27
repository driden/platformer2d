using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningChest1 : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(WaitForSceneLoad());
    }
    
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Scenes/EndGame");
    }
}
