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
                    manager.diagUI.SetActive(false);
                }
            }
        }
    }
}
