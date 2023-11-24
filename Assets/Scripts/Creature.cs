using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public bool enemy;
    public int health;
    public int damage;
    Player player; 
    Manager manager;

    public bool dropsItems;
    public Item[] itemsToDrop;


    [HideInInspector] public int directionFromPlayer;//player perspective = if player is left of this crtr dir = 1 (^0 >1 v2 <3)
    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<Manager>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //spawn drops (if drops items)
            if(dropsItems)
            {
                for(int i = 0; i<itemsToDrop.Length; i++)
                {
                    manager.AddToInventory(itemsToDrop[i]);
                } 
            }
            Destroy(gameObject);
        }

        if(Vector2.Distance(transform.position,player.transform.position) < 0.5)
        {
            player.canAttack = true;
        }
    }

    private void OnMouseDown()
    {
        player.Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Attack")
        {
            collision.GetComponent<Collider2D>().enabled = false;

            if (collision.GetComponent<Projectile>() == null)
            {
                //print("Took damage");
                health -= player.damage;

                Vector3 direction = transform.position - player.transform.position;
                direction.Normalize();
                transform.position += (direction / 10) * player.damage;
            }
            else
            {
                health -= collision.GetComponent<Projectile>().damage;
            }
        }
    }

}
