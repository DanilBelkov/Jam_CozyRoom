using UnityEngine;

public class Target : MonoBehaviour
{

    private void OnMouseDown()
    {
        QuestManager.CheckTargetQuest(this);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
