using UnityEngine;

public class Quest : MonoBehaviour
{ 
    [SerializeField]
    private int _id;

    [SerializeField]
    public Target _targetQuest;

    [SerializeField]
    private string _questName;

    [SerializeField]
    private string _questDescription;

    private bool _completed;

    public bool CheckTarget(Target target) => _targetQuest.name == target.name;
    public void Completed()
    {
        _completed = true;
        _targetQuest.Destroy();
    }

    public bool IsCompleted() => _completed;
        
    public void SetTarget(Target target)
    {
        _targetQuest = target;
    }
    public int GetId() => _id;
}
