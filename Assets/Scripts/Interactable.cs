using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        // Логика взаимодействия с предметом
        Debug.Log("Interacted with " + gameObject.name);
    }
}
