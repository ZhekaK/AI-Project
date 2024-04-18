using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrows : MonoBehaviour
{
    public int ready;

    public float speedArrow;

    public float lifetime;
    void Update()
    {
        if(ready == 1)
        {
            transform.Translate(Vector2.up * -speedArrow * Time.deltaTime);
            Invoke("Destroy", lifetime);
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
