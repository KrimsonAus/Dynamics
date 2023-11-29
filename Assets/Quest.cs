using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questId;
    public string questName;
    [TextArea(8, 16)]
    public string questText;
    public bool started;
    public bool finished;
    public Item[] rewards;

    Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager=FindAnyObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(started && finished)
        {
            for (int i = 0; i < rewards.Length; i++)
            {
                manager.AddToInventory(rewards[i]);
            }
            started = false;
        }
    }
}
