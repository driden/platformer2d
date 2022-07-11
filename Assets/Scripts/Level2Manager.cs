using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    [SerializeField] public GameObject enemy1;
    [SerializeField] public GameObject enemy2;
    [SerializeField] public GameObject enemy3;

    public SFXManager sfx;
    private GameObject[] rocks;

    private static bool _enemy1IsDead = false;
    private static bool _enemy2IsDead = false;
    private static bool _enemy3IsDead = false;
    private bool _lockWinCondition = false;
    private bool pathIsClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        _enemy1IsDead = false;
        _enemy2IsDead = false;
        _enemy3IsDead = false;
        if (rocks == null) rocks = GameObject.FindGameObjectsWithTag("RocksPath");
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy1) _enemy1IsDead = true;
        if (!enemy2) _enemy2IsDead = true;
        if (!enemy3) _enemy3IsDead = true;

        OpenRockPath();

        if (WinConditionIsMet())
        {
            _lockWinCondition = true;
            //SceneManager.LoadScene("Scenes/WinGame");
        }
    }

    bool WinConditionIsMet()
    {
        return EnemiesAreDead() && !_lockWinCondition;
    }

    public static bool EnemiesAreDead()
    {
        return _enemy1IsDead && _enemy2IsDead && _enemy3IsDead;
    }


    private void OpenRockPath(){
        if (EnemiesAreDead() && pathIsClosed)
        {
            pathIsClosed = false;
            this.sfx.playWin();
            foreach (GameObject rock in rocks)
            {
                Destroy(rock);
            }
       }
    }



        

}