using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int healthEnemy;
    public GameObject damageEffect;
    public patrulEnemy patrulEnemy;
    float stopTime;
    public float startStopTime;
    public float normalSpeed;
    public Animator anim;
    public GameObject effect;
    public enemyDamage enemyDamage;
    public bool running;
    public GameObject drop;

    void Start()
    {
        normalSpeed = patrulEnemy.speed;
    }

    void Update()
    {
        if(stopTime <= 0)
        {
            if(running)
            {
                patrulEnemy.speed = normalSpeed;
                anim.SetBool("running", true);
            }
            if(!running)
            {
                patrulEnemy.speed = normalSpeed;
            }
        }
        else
        {
            patrulEnemy.speed = 0;
            stopTime -= Time.deltaTime;
        }
        if(healthEnemy <= 0)
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            int rands = Random.Range(0, 1000);
            if (rands <= 200)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            else if (rands > 200 && rands <= 400)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            else if (rands > 400 && rands <= 600)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            else if (rands > 600 && rands <= 750)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            else if (rands > 750 && rands <= 900)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            else if (rands > 900 && rands <= 1000)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
                Instantiate(drop, transform.position, Quaternion.identity);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        healthEnemy -= damage;
        if(running)
        {
            anim.SetBool("isattack", false);
            anim.SetBool("running", false);
        }
        if(!running)
        {
            anim.SetBool("isattack", false);
        }
        enemyDamage.timeBtwAttack = enemyDamage.startTimeBtwAttack;
        if(healthEnemy > 0)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
        }
    }
}
