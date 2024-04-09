using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<Quest> ActiveQuests;
    public TMP_Text questText;

    public void AddQuest(Quest quest)
    {
        ActiveQuests.Add(quest);
        UpdateQuestText();
    }

    public void CheckQuestCompletion()
    {
        foreach (var quest in ActiveQuests)
        {
            if (quest.CheckCompletionCondition(FindObjectOfType<PlayerController>()))
            {
                quest.IsCompleted = true;
                quest.GetComponent<InteractionObject>().dialogueLines[0] = "You have completed the quest! Here is the stone I promised you!";
            }
        }
    }

    private void UpdateQuestText()
    {
        questText.text = "";
        foreach (var quest in ActiveQuests)
        {
            if (!quest.IsCompleted)
            {
                questText.text += "Quest: " + quest.name + "\n";
            }
        }
    }

}
