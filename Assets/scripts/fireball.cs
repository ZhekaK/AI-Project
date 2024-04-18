using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speedFb;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject effect;
    Animator camAnim;

    void Start()
    {
        Invoke("DestroyFb", lifetime);
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if(hitInfo.collider.CompareTag("boss"))
            {
                hitInfo.collider.GetComponent<enemyBoss1>().TakeDamage(damage);
            }
            if(hitInfo.collider.CompareTag("boss2"))
            {
                hitInfo.collider.GetComponent<enemyBoss2>().TakeDamage(damage);
            }
            DestroyFb();
            camAnim.SetTrigger("shake");
        }
        transform.Translate(Vector2.up * speedFb * Time.deltaTime);
    }

    public void DestroyFb()
    {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
