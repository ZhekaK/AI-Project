using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameswitch4 : MonoBehaviour
{
    public GameObject activeFramefour;
    public GameObject paralax;
    public GameObject clouds;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFramefour.SetActive(true);
            paralax.SetActive(false);
            clouds.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFramefour.SetActive(false);
            paralax.SetActive(true);
            clouds.SetActive(true);
        }
    }
}
