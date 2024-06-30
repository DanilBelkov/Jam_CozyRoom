using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _Pages;

    private GameObject _Page;

    private void Awake()
    {
        _Page = _Pages.First();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }

    public void NextPage()
    {
        _Page.SetActive(false);
        _Page = _Pages[_Pages.IndexOf(_Page) + 1];
    }
}
