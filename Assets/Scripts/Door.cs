using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    Player player;
    Manager manager;
    GameObject space;
    public Vector2 destination;

    float timer;
    bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;

        manager = FindAnyObjectByType<Manager>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.gameObject.transform.position);

        if (dist < 0.5f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //move to destination
                animator.enabled = true;
                startTimer = true;
            }
            //show space bar
            if (space == null)
            {
                space = Instantiate(manager.spaceBarIndicator, transform);
            }
        }
        else
        {
            //kill space bar
            if (space != null)
            {
                Destroy(space);
            }
        }

        if (startTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 0.75f)
            {
                player.transform.position = destination;
            }
            if (timer >= 1)
            {
                player.camera.transform.position = destination;
                timer = 0;
                startTimer=false;
            }
        }
    }
}
