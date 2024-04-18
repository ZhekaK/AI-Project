using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulEnemy : MonoBehaviour
{
    public float speed;
    private float _speed;
    public float positionOfPatrul;
    public Transform point;
    bool moviengRight;
    bool facingRight;

    Transform player;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;

    private float oldPosition;
    private float movementDirection;

    public bool running;
    public Animator anim;

    [Space, Header("Debug")]

    public Vector3 detectPlayerPosition;
    public bool firstDetection = true;

    public int left = 0;
    public int right = 0;
    public direction direction;
    [Space, SerializeField] private int mobID;

    void Start()
    {
        for(int i = 0; i < DetectionData.IDs.Count;  i++)
        {
            if(mobID == DetectionData.IDs[i])
            {
                left += DetectionData.LeftDetect[i];
                right += DetectionData.RightDetect[i];
            }
        }
        if(left - right < 0)
        {
            direction = direction.Right;
        }
        else if (left - right > 0)
        {
            direction = direction.Left;
        }
        else
        {
            direction = (direction)Random.Range(0, 1.99f);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        _speed = speed;
    }

    void Update()
    {
        oldPosition = transform.position.x;
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrul && angry == false)
        {
            chill = true;
        }
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
            if (firstDetection)
            {
                detectPlayerPosition = transform.position;
                firstDetection = false;
                Invoke(nameof(SavedPlayerDirection), 0.5f);
            }
        }
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if(chill == true)
        {
            Chill();
        }
        else if(angry == true)
        {
            Angry();
        }
        else if(goBack == true)
        {
            GoBack();
        }
        movementDirection = oldPosition - transform.position.x;
        if(facingRight == false && movementDirection < 0)
        {
            Flip();
        }
        else if (facingRight == true && movementDirection > 0)
        {
            Flip();
        }
    }

    private void SavedPlayerDirection()
    {
        float Range = transform.position.x - detectPlayerPosition.x;
        if(Range < 0)
        {
            DetectionData.LeftDetect.Add(1);
            DetectionData.RightDetect.Add(0);
        }
        else if(Range > 0)
        {
            DetectionData.RightDetect.Add(1);
            DetectionData.LeftDetect.Add(0);
        }
        //DetectionData.positionDetect = detectPlayerPosition.x;
        DetectionData.IDs.Add(mobID);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Chill()
    {
        if(!running)
        {
            if(transform.position.x > point.position.x + positionOfPatrul)
            {
                direction = direction.Left;
            }
            else if(transform.position.x < point.position.x - positionOfPatrul)
            {
                direction = direction.Right;
            }
            if(direction == direction.Right)
            {
                transform.position = new Vector2(transform.position.x + (speed / 2) * Time.deltaTime, transform.position.y);
            }
            else if (direction == direction.Left)
            {
                transform.position = new Vector2(transform.position.x - (speed / 2) * Time.deltaTime, transform.position.y);
            }
        }
        if(running)
        {
            if(transform.position.x > point.position.x + positionOfPatrul)
            {
                direction = direction.Left;
            }
            else if(transform.position.x < point.position.x - positionOfPatrul)
            {
                direction = direction.Right;
            }
            if(direction == direction.Right)
            {
                transform.position = new Vector2(transform.position.x + (speed / 2) * Time.deltaTime, transform.position.y);
            }
            else if(direction == direction.Left)
            {
                transform.position = new Vector2(transform.position.x - (speed / 2) * Time.deltaTime, transform.position.y);
            }
            anim.SetBool("running", false);
        }
    }

    void Angry()
    {
        if(!running)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        if(running)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("running", true);
        }
    }

    void GoBack()
    {
        if(!running)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        }
        if(running)
        {
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            anim.SetBool("running", true);
        }    
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        speed = 0;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        speed = _speed;
    //    }
    //}
}
