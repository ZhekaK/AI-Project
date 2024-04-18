using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falltrap : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void rar()
    {
        fp();
        Destroy(gameObject, 1f);
    }

    void fp()
    {
        rb.isKinematic = false;
    }
}
