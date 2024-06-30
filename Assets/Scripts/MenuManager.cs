using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static bool GameAcvive;
    public static bool IsFinal;

    [SerializeField]
    private GameObject _menuCanvas;

    [SerializeField]
    private GameObject _gameCanvas;

    [SerializeField]
    private GameObject _finalCanvas;

    void Awake()
    {
        GameAcvive = true;
        _menuCanvas.SetActive(false);
        _finalCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
        }

        if (IsFinal)
            Final();

    }
    public void Final()
    {
        _menuCanvas.SetActive(false);
        _gameCanvas.SetActive(false);
        _finalCanvas.SetActive(true);
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
