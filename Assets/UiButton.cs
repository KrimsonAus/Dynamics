using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    public bool disableMenu;
    public GameObject menuToDisable;
    public bool enableMenu;
    public GameObject menuToEnable;

    public bool alterCoin;
    public int coinAmountToAlter;

    public bool needCoinToBuy;
    public int cost;

    public bool giveItem;
    public Item itemToGive;

    Player player;
    Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        manager = FindAnyObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(disableMenu)
        {
            menuToDisable.SetActive(false);
        }
        if(enableMenu)
        {
            menuToEnable.SetActive(true);
        }

        if(alterCoin)
        {
            if(player.coin >= coinAmountToAlter)
            {
                player.coin += coinAmountToAlter;
            }
        }

        if (needCoinToBuy)
        {
            if (player.coin >= cost)
            {
                if (giveItem)
                {
                    manager.AddToInventory(itemToGive);
                }
            }
        }
        else if (giveItem)
        {
            manager.AddToInventory(itemToGive);
        }
    }
}
