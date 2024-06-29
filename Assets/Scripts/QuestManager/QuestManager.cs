using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{

    [SerializeField]
    private List<Quest> _localQuests;

    private static List<Quest> _quests;

    private void Awake()
    {
        if (_quests == null)
            _quests = _localQuests;
    }

    public static void CheckTargetQuest(Target target)
    {
        if (_quests != null && target != null)
        {
            var quest = _quests.Where(x => !x.IsCompleted()).FirstOrDefault(x => x.CheckTarget(target));
            if (quest != null)
                quest.Completed();
        }
    }
}
