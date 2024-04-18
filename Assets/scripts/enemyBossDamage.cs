using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBossDamage : MonoBehaviour
{
    public Animator anim;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public int enemyDamagee;
    public int enemySuperDamagee;
    public player player;
    public GameObject damageEffect;
    public int schet;


    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0 && schet < 3)
            {
                anim.SetBool("isattack", true);
            }
            if(timeBtwAttack <= 0 && schet >= 3)
            {
                anim.SetBool("issuperattack", true);
            }
            if(timeBtwAttack > 0)
            {
                timeBtwAttack -= Time.deltaTime;
                anim.SetBool("isattack", false);
                anim.SetBool("issuperattack", false);
            }
        }
    }

    public void OnEnemyAttack()
    {
        player.health -= enemyDamagee;
        timeBtwAttack = startTimeBtwAttack;
        Instantiate(damageEffect, player.transform.position, Quaternion.identity);
        schet++;
    }

    public void OnEnemySuperAttack()
    {
        player.health -= enemySuperDamagee;
        timeBtwAttack = startTimeBtwAttack;
        Instantiate(damageEffect, player.transform.position, Quaternion.identity);
        schet = 0;
    }
}
