using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceIndicatorPopup : MonoBehaviour
{
    Manager manager;
    Player player;
    GameObject space;
    public float distMax;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindAnyObjectByType<Manager>();
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.gameObject.transform.position, transform.position);

        if (dist < distMax)
        {
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
    }
}
