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
    public TMPro.TextMeshPro coinsText;

    [Header("Misc")]
    public GameObject dir;

    [HideInInspector] public GameObject cam;
   [HideInInspector] public int direction;

    public GameObject attack;
    //DEBUGCODE
    int selectedItem;

    [HideInInspector] public bool onUI;
    [HideInInspector] public bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "$" + coin;
        transform.position += transform.up * Input.GetAxis("Vertical") * Time.deltaTime * speed + transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        DetermineDir();
        //DetermineMouseDir();

        //dir.transform.eulerAngles = face mouse\\

        /*
        arms.transform.position -= transform.up * Input.GetAxis("Vertical") * Time.deltaTime * speed + transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
                
        }

        if (Input.GetKeyDown(KeyCode.Space) && equippedHeld1 != null)
        {
            if (canAttack)
            {
                Instantiate(attack, dir.transform.position, dir.transform.rotation);
                canAttack = false;
            }
            if (equippedHeld1.spawnObjectOnUse)
            {
                Instantiate(equippedHeld1.objectToSpawn, dir.transform.position, dir.transform.rotation);
            }
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

    void DetermineMouseDir()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        dir.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    void DetermineDir()
    {
        if (Input.GetAxis("Horizontal") > Input.GetAxis("Vertical") && Input.GetAxis("Horizontal") > 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -90);
            direction = 1;
        }
        if (Input.GetAxis("Vertical") < Input.GetAxis("Horizontal") && Input.GetAxis("Vertical") < 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -180);
            direction = 2;
        }
        if (Input.GetAxis("Horizontal") < Input.GetAxis("Vertical") && Input.GetAxis("Horizontal") < 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, -180 + -90);
            direction = 3;
        }
        if (Input.GetAxis("Vertical") > Input.GetAxis("Horizontal") && Input.GetAxis("Vertical") > 0)
        {
            dir.transform.eulerAngles = new Vector3(0, 0, 0);
            direction = 0;
        }
    }

    public void Attack()
    {
        Instantiate(attack, dir.transform);

        if (equippedHeld1 != null && equippedHeld1.spawnObjectOnUse)
        {
            Instantiate(equippedHeld1.objectToSpawn, dir.transform.position, dir.transform.rotation);
        }
    }
}
