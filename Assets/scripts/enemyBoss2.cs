using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyBoss2 : MonoBehaviour
{
    public int healthEnemy;
    public GameObject damageEffect;
    public patrulEnemy patrulEnemy;
    public float stopTime;
    public float startStopTime;
    public float normalSpeed;
    public Animator anim;
    public GameObject effect;
    public enemyBossDamage enemyDamage;
    public bool running;
    public GameObject drop;
    public GameObject soul;
    public GameObject portal;
    public player Player;

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
            Instantiate(drop, transform.position, Quaternion.identity);
            Instantiate(drop, transform.position, Quaternion.identity);
            Instantiate(drop, transform.position, Quaternion.identity);
            Instantiate(drop, transform.position, Quaternion.identity);
            Instantiate(drop, transform.position, Quaternion.identity);
            if(Player.scorpBoss == 0){
                Instantiate(soul, transform.position, Quaternion.identity);
                Player.scorpBoss = 1;
            }
            portal.SetActive(true);
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
        //enemyDamage.timeBtwAttack = enemyDamage.startTimeBtwAttack;
        if(healthEnemy > 0)
        {
            Instantiate(damageEffect, transform.position, Quaternion.identity);
        }
    }
}
