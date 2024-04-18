using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameswitch1 : MonoBehaviour
{
    public GameObject cam;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            cam.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            cam.SetActive(false);
        }
    }
}
