using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomSwitchTrigger : MonoBehaviour
{
    public string nextSceneName; // Имя следующей сцены, которая загрузится при входе в зону

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что в триггерную зону входит персонаж (или другой объект)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            // Загружаем следующую сцену
            SceneManager.LoadScene(nextSceneName);
        }
    }
}