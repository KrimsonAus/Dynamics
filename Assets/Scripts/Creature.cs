using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public bool enemy;
    public float speed;
    public int health;
    public int damage;
    Player player; 
    Manager manager;

    public bool dropsItems;
    public Item[] itemsToDrop;

    public float detectionDistance;
    public float attackDistance;

    bool attacking;
    float attackTimer;
    public float attackTime;

    public GameObject enemyAttack;
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

        if(enemy && Vector2.Distance(transform.position, player.transform.position) < detectionDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }

        if(enemy && Vector2.Distance(transform.position, player.transform.position) < attackDistance)
        {
            attacking = true;
        }
        else
        {
            attacking=false;
        }

        if (attacking)
        {
            attackTimer += Time.deltaTime;

            if(attackTimer > attackTime)
            {
                Instantiate(enemyAttack, player.transform.position, Quaternion.identity);
                //attack
                player.health -= damage;
                attackTimer = 0;
            }
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
