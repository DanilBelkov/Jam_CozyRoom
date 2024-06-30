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
    private GameObject _localTextTemplate;
    private static GameObject _textTemplate;

    [SerializeField]
    private List<Quest> _localQuests;

    [SerializeField]
    private Quest _localFinalQuest;

    private static Quest _finalQuest;

    private static List<Quest> _quests;

    private void Awake()
    {
        if (_quests == null)
            _quests = _localQuests;

        if (_uiContent == null)
            _uiContent = _uiContentPanel;

        if (_finalQuest == null)
            _finalQuest = _localFinalQuest;

        if (_textTemplate == null)
            _textTemplate = _localTextTemplate;

        if (_quests != null)
            _quests.ForEach(quest =>
            {
                var t = GameObject.Instantiate(_textTemplate);
                t.transform.SetParent(_uiContent.transform, false);
                t.GetComponent<TextMeshProUGUI>().text = quest.GetDescription();
            });
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
            if (_quests.All(x => x.IsCompleted()) && !_finalQuest.IsCompleted())
            {
                var t = GameObject.Instantiate(_textTemplate);
                t.transform.SetParent(_uiContent.transform, false);
                t.GetComponent<TextMeshProUGUI>().text = _finalQuest.GetDescription();
            }
        }
        if (_quests.All(x => x.IsCompleted()) && !_finalQuest.IsCompleted() && _finalQuest.CheckTarget(target))
        {
            _finalQuest.Completed();
            MenuManager.IsFinal = true;
        }
    }
}
