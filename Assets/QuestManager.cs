using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int currentQuestId;
    public TMPro.TextMeshPro questList;
    public Quest[] quests;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        questList.text = "";
        for (int i = 0; i < quests.Length; i++)
        {
            if (quests[i] != null)
            {
                questList.text += quests[i].questName + "\n";
            }
        }
    }
}
