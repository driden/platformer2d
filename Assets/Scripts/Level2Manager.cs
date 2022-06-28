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

    private bool _enemy1IsDead = false;
    private bool _enemy2IsDead = false;
    private bool _enemy3IsDead = false;
    private bool _lockWinCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        _enemy1IsDead = false;
        _enemy2IsDead = false;
        _enemy3IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy1) _enemy1IsDead = true;
        if (!enemy2) _enemy2IsDead = true;
        if (!enemy3) _enemy3IsDead = true;

        if (WinConditionIsMet())
        {
            _lockWinCondition = true;
            SceneManager.LoadScene("Scenes/EndGame");
        }
    }

    bool WinConditionIsMet()
    {
        return _enemy1IsDead && _enemy2IsDead && _enemy3IsDead && !_lockWinCondition;
    }
}