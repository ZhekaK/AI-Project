using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallplatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentPosition;
    bool moveingBack;
    public GameObject ara;
    public GameObject particles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && moveingBack == false)
        {
            Invoke("fp", 1f);
            Invoke("active2", 2f);
            Instantiate(particles, transform.position, Quaternion.identity);
        }
    }

    void active1()
    {
        ara.SetActive(true);
    }
    void active2()
    {
        ara.SetActive(false);
        Instantiate(particles, transform.position, Quaternion.identity);
    }
    void fp()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", 3f);
        Invoke("active1", 2f);
        Instantiate(particles, transform.position, Quaternion.identity);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveingBack = true;
    }

    void Update()
    {
        if (moveingBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, 15f * Time.deltaTime);
        }
        if(transform.position.y == currentPosition.y)
        {
            moveingBack = false;
        }
    }
}
