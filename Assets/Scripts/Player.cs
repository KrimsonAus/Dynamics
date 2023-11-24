using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Variables")]
    public GameObject arms;
    public Animator animator;
    public Item[] inventory;
    public InventorySlot[] inventorySlots;
    public SpriteRenderer rightHand;
    public Item equippedHeld1;
    public Item equippedHeld2;

    [Header("Stats")]
    public int health;
    public int mana;
    public int stamina;
    public int coin;
    public float speed;
    [HideInInspector] public int damage;

    [Header("Misc")]
   [HideInInspector] public GameObject camera;
    public GameObject dir;
   [HideInInspector] public int direction;

    public GameObject attack;
    //DEBUGCODE
    int selectedItem;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Input.GetAxis("Vertical") * Time.deltaTime * speed + transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        if(Input.GetAxis("Horizontal")> Input.GetAxis("Vertical") && Input.GetAxis("Horizontal") > 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -90);
            direction = 1;
        }
        if(Input.GetAxis("Vertical")< Input.GetAxis("Horizontal") && Input.GetAxis("Vertical") < 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -180);
            direction = 2;
        }
        if(Input.GetAxis("Horizontal") < Input.GetAxis("Vertical") && Input.GetAxis("Horizontal") < 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -180 + -90);
            direction= 3;
        }
        if(Input.GetAxis("Vertical") > Input.GetAxis("Horizontal") && Input.GetAxis("Vertical") > 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, 0);
            direction = 0;
        }

        /*
        arms.transform.position -= transform.up * Input.GetAxis("Vertical") * Time.deltaTime * speed + transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(attack, dir.transform);
        }

        //rightHand = equiped item 1 - get sprite from item (if equipable)
        if (equippedHeld1!=null)
        {
            rightHand.sprite = equippedHeld1.sprite;
        }
        else
        {
            rightHand.sprite = null;
        }

        if (equippedHeld1 != null)
        {
            damage = equippedHeld1.attack;
        }
        else
        {
            damage = 0;
        }

        
        //NOT DEBUGCODE

        if (inventory[selectedItem]!= null && inventory[selectedItem].equipable)
        {
            equippedHeld1 = inventory[selectedItem];
        }
        else
        {
            equippedHeld1=null;
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].id = i;
            if (inventory[i] != null)
            {
                inventorySlots[i].sr.sprite = inventory[i].sprite;
            }
            else
            {
                inventorySlots[i].sr.sprite = null;
            }

            if(i > 0)
            {
                if (inventory[i-1] == null)
                {
                    inventory[i - 1] = inventory[i];
                    inventory[i]=null;
                }
            }
        }
    }

    public void RightAttackDone()
    {
        animator.SetBool("Attack", false);
    }

    public void Consume(int id)
    {
        if (inventory[id]!= null)
        {
            if (inventory[id].equipable)
            {
                selectedItem = id;
            }
            if (inventory[id].consumable)
            {
                health += inventory[id].healthToGive;
                mana += inventory[id].manaToGive;
                stamina += inventory[id].staminaToGive;
                coin += inventory[id].coinToGive;
                inventory[id] = null;
            }
        }
    }

    /*
    healthToGive;
    manaToGive;
    staminaToGive;
    coinToGive;
    */
}
