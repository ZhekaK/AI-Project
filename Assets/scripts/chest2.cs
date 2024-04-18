using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest2 : MonoBehaviour
{
    public GameObject[] drop;
    public Animator anim;
    public player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("triggered", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("triggered", false);
        }
    }

    public void ok()
    {
        drop[0].SetActive(true);
        if(player.amuletOfWater == 0)
        {
            drop[1].SetActive(true);
        }
        Destroy(gameObject);
    }
}

