using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameswitch2 : MonoBehaviour
{
    public GameObject activeFrametwo;
    public GameObject paralax;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFrametwo.SetActive(true);
            paralax.SetActive(false);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            activeFrametwo.SetActive(false);
            paralax.SetActive(true);
        }
    }
}
