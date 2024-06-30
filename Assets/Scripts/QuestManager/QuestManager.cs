using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject _uiContentPanel;

    private static GameObject _uiContent;

    [SerializeField]
    private GameObject _textTemplate;

    [SerializeField]
    private List<Quest> _localQuests;

    [SerializeField]
    private Quest _finalQuest;

    private static List<Quest> _quests;

    private void Awake()
    {
        if (_quests == null)
            _quests = _localQuests;

        if (_uiContent == null)
            _uiContent = _uiContentPanel;

        if (_quests != null)
            _quests.ForEach(quest =>
            {
                var t = GameObject.Instantiate(_textTemplate);
                t.transform.SetParent(_uiContent.transform, false);
                t.GetComponent<TextMeshProUGUI>().text = quest.GetDescription();
            });
    }
    private void Update()
    {
        if (_quests.All(x => x.IsCompleted()))
            ActivateFinalQuest();
    }
    private void ActivateFinalQuest()
    {
        if (!_finalQuest.IsCompleted())
        {
            var t = GameObject.Instantiate(_textTemplate);
            t.transform.SetParent(_uiContent.transform, false);
            t.GetComponent<TextMeshProUGUI>().text = _finalQuest.GetDescription();
        }
    }
    public static void CheckTargetQuest(Target target)
    {
        if (_quests != null && target != null)
        {
            var quest = _quests.Where(x => !x.IsCompleted()).FirstOrDefault(x => x.CheckTarget(target));
            if (quest != null)
            {
                var updateNumberQuest = _quests.IndexOf(quest);
                var text = _uiContent.transform.GetChild(updateNumberQuest);
                text.gameObject.GetComponent<TextMeshProUGUI>().text = $"<s>{quest.GetDescription()}<s>";
                text.gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
                quest.Completed();
            }
        }
    }
}
