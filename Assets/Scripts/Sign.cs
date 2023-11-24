using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    Player player;
    Manager manager;
    [TextArea(4, 16)]
    public string signText;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        manager = FindAnyObjectByType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.gameObject.transform.position, transform.position);

        if (dist < 0.4f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.signUI.SetActive(true);
                manager.signUIText.text = signText;
            }
        }
    }
}
