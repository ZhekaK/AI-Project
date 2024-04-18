using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyif : MonoBehaviour
{
    private player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.mooshrom == 1)
        {
            Destroy(gameObject);
        }
    }
}
