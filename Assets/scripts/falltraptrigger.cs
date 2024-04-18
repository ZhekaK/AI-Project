using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falltraptrigger : MonoBehaviour
{
    public falltrap ft;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            ft.rar();
            Destroy(gameObject);
        }
    }
}
