using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public Animator anim;
    public float timeBtwAttack;
    public float startTimeBtwAttack;
    public int enemyDamagee;
    public player player;
    public GameObject damageEffect;


    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                anim.SetBool("isattack", true);
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
                anim.SetBool("isattack", false);
            }
        }
    }

    public void OnEnemyAttack()
    {
        player.health -= enemyDamagee;
        timeBtwAttack = startTimeBtwAttack;
        Instantiate(damageEffect, player.transform.position, Quaternion.identity);
    }
}
