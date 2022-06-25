using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChest : MonoBehaviour
{
    public SFXManager fx;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            fx.playWin();
            StartCoroutine(WaitForSceneLoad());
        }
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Scenes/EndGame");
    }
}
