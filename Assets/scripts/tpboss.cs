using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpboss : MonoBehaviour
{
    public Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("trigg", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("trigg", false);
        }
    }
}
