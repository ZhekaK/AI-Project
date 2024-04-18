using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameswitch3 : MonoBehaviour
{
    public GameObject activeFramethree;
    public GameObject paralax;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFramethree.SetActive(true);
            paralax.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFramethree.SetActive(false);
            paralax.SetActive(true);
        }
    }
}
