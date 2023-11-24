using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    Player player;
    public GameObject spaceBarIndicator;
    public GameObject signUI;
    public TMPro.TextMeshPro signUIText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(Item item)
    {
        for (int i = 0; i < player.inventory.Length; i++)
        {
            if (player.inventory[i] == null)
            {
                player.inventory[i] = item;
                break;
            }
        }
    }
}
