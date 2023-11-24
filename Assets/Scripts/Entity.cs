using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public bool interactable;
    public bool giveItem;
    public Item itemToGive;
    public bool takeItem;
    public Item itemToTake;
    Player player;
    public bool destroyAfterUse;
    public bool onlyActivateCertNoTimes;
    public int amountOfTimesActivatable;
    Manager manager;
    public bool animateWhenActivate;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        manager =  FindAnyObjectByType<Manager>();
        player = FindAnyObjectByType<Player>();

        if(animateWhenActivate)
        {
            animator.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            float dist = Vector2.Distance(player.gameObject.transform.position, transform.position);

            if (dist < 0.4f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(onlyActivateCertNoTimes && amountOfTimesActivatable > 0 || !onlyActivateCertNoTimes) 
                    {
                        amountOfTimesActivatable--;

                        manager.AddToInventory(itemToGive);

                        if (animateWhenActivate)
                        {
                            animator.enabled = true;
                        }

                        if (destroyAfterUse)
                        {
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
}
