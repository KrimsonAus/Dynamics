using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.gameObject.transform.position, transform.position);

        if (dist < 0.4f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shopUI.SetActive(true);
            }
        }
    }
}
