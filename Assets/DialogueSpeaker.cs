using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{
    public float interactDist;
    Player player;
    Manager manager;
    [TextArea]
    public string[] dialogueText;
    public int index;
    [Header("Quests")]
    public bool startQuest;
    public Quest questToStart;
    public bool finishQuest;
    public Quest questToFinish;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        manager = FindAnyObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) < interactDist)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (index < dialogueText.Length)
                {
                    //show diag UI
                    if (!manager.diagUI.activeSelf)
                    {
                        manager.diagUI.SetActive(true);
                    }
                    manager.diagText.text = dialogueText[index];
                    index++;
                }
                else
                {
                    if (startQuest)
                    {
                        for (int i = 0; i < player.GetComponent<QuestManager>().quests.Length; i++)
                        {
                            if (player.GetComponent<QuestManager>().quests[i] == null)
                            {

                                player.GetComponent<QuestManager>().quests[i] = questToStart;
                                player.GetComponent<QuestManager>().quests[i].started = true;
                                break;
                            }
                        }
                        startQuest = false;
                    }
                    manager.diagUI.SetActive(false);
                }
            }
        }
    }
}
