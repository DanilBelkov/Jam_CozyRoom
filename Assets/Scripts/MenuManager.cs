using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool GameAcvive;

    [SerializeField]
    private GameObject _menuCanvas;

    [SerializeField]
    private GameObject _gameCanvas;
    void Awake()
    {
        GameAcvive = true;
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
        }

    }

    public void Quite()
    {
        Application.Quit();
    }
    public void Continue()
    {
        GameAcvive = true;
        _gameCanvas.SetActive(true);
        _menuCanvas.SetActive(false);
    }
    public void Stop()
    {
        GameAcvive = false;
        _gameCanvas.SetActive(false);
        _menuCanvas.SetActive(true);
    }
}
