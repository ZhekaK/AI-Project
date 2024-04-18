using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowtrap : MonoBehaviour
{
    public arrows arrows;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            arrows.ready = 1;
        }
    }
}
