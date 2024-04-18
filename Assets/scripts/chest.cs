using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public GameObject[] drop;
    public Animator anim;

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
        drop[1].SetActive(true);
        Destroy(gameObject);
    }
}
