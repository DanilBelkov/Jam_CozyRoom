using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomSwitchTrigger : MonoBehaviour
{
    public string nextSceneName; // ��� ��������� �����, ������� ���������� ��� ����� � ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���������, ��� � ���������� ���� ������ �������� (��� ������ ������)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");
            // ��������� ��������� �����
            SceneManager.LoadScene(nextSceneName);
        }
    }
}