using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Weapon")]
    public bool weapon;
    public int attack;
    public int durability;
    public bool spawnObjectOnUse;
    public GameObject objectToSpawn;
    [Header("Consumable")]
    public bool consumable;
    public int healthToGive;
    public int manaToGive;
    public int staminaToGive;
    public int coinToGive;
    [Header("Misc")]
    public Sprite sprite;
    public bool equipable;
    public int worth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
