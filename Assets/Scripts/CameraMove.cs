using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    
    public void LateUpdate()
    {
        if (player)
        {
            float x;
            if (player.transform.position.x < -10)
                return;
            else if (player.transform.position.x > 55)
                return;
            else
                x = player.position.x;

            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
