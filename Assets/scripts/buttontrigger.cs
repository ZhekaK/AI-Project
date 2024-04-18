using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttontrigger : MonoBehaviour
{
    public Animator anim;
    //public GameObject frame;
    //public GameObject[] otherFrames;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("triggered", true);
            //frame.SetActive(true);
            //foreach(GameObject frame in otherFrames)
            //{
                //frame.SetActive(false);
            //}
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("triggered", false);
        }
    }
}
