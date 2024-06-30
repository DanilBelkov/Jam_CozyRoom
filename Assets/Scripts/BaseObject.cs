using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{


    private void OnMouseDown()
    {
        GetComponent<Animator>().SetTrigger("click");
    }
}
