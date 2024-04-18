using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public float attackSpeed;
    public Animator camAnim;
    private player player;

    private void Start()
    {
        player = GetComponentInParent<player>();
        player._attackSpeed = attackSpeed;
    }

    void Update()
    {
        if(player.test == 1)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        if(enemies[i].CompareTag("boss")){
                            enemies[i].GetComponent<enemyBoss1>().TakeDamage(damage);
                            camAnim.SetTrigger("shake");
                        }
                        else if(enemies[i].CompareTag("boss2")){
                            enemies[i].GetComponent<enemyBoss2>().TakeDamage(damage);
                            camAnim.SetTrigger("shake");
                        }
                        else{
                            enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                            camAnim.SetTrigger("shake");
                        }
                    }
                }
            player.test = 0;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
