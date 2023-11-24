using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [Header("Menu Button")]
    public bool disableMenu;
    public GameObject menuToDisable;
    public bool enableMenu;
    public GameObject menuToEnable;

    [Header("Purchase Button")]
    public bool needCoinToBuy;
    public int cost;
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

        
        if (needCoinToBuy)
        {
            if (player.coin >= cost)
            {
                player.coin -= cost;
                manager.AddToInventory(itemToGive);
            }
        }
    }
}
