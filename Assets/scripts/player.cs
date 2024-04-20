using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    bool facingRight = true;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public GameObject map;
    public float jumpInput;
    
    public Text healthT;
    public Text coinsT;
    public Text numberOfLivesT;
    
    public GameObject knife;
    public GameObject sword;
    public GameObject swordTwo;
    public GameObject javelin;
    public GameObject axe;
    public GameObject halberd;
    public int amuletOfWater = 0;
    public int amuletOfPoison = 0;
    public int cloakGravity = 0;
    public int fireStaff = 0;
    public int healthStaff = 0;
    public int speedyBoots = 0;
    public float speedModify;
    public int effect = 0;
    public startfireball startfireball;
    public GameObject fire;
    public VectorValue pos;
    public int snakeBoss;
    public int soul;
    float temp;
    public int karma;
    public int mooshrom;
    public int ik;
    public GameObject damageEffects;
    public int bossKey;
    public GameObject notAllow;
    public int scorpBoss;
    public int questNistein;
    public int nistein;
    [HideInInspector] public int test = 0;
    private bool attack;
    [HideInInspector] public float _attackSpeed;
    private bool start = false;
    [Space]
    [SerializeField] private GameObject StartCamera;
    [SerializeField] private GameObject PlayerCamera;
    [Space, Header("Control")]
    public int numberOfLives = 5;
    public int health;
    public int coins;
    public int weapon = 1;
    [Space]
    [SerializeField] private bool RESET_GAME;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        transform.position = pos.initialValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        load();
        if(numberOfLives <= 0)
        {
            numberOfLives = 5;
        }
        if(weapon == 0)
        {
            weapon = 1;
        }
        if(health <= 0)
        {
            health = numberOfLives;
        }
        temp = jumpForce;
        Invoke("fix", 20f);
        //Time.timeScale = 0;
    }

    void Update()
    {
        if(RESET_GAME)
        {
            StopAllCoroutines();
            PlayerPrefs.DeleteAll();
            return;
        }
        if (start)
        {
            save();
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack)
            {
                anim.SetTrigger("attack");
                attack = true;
            }
            if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight == true && moveInput < 0)
            {
                Flip();
            }
            jumpInput = Input.GetAxis("Jump");
            isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
            if (isGrounded == true && jumpInput >= .5f)
            {
                rb.velocity = Vector2.up * jumpForce;
                anim.SetTrigger("takeOf");
            }
            if (moveInput == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
            if (isGrounded == true)
            {
                anim.SetBool("isJumping", false);
            }
            else
            {
                anim.SetBool("isJumping", true);
            }
            if (numberOfLives > 99)
            {
                numberOfLives = 99;
            }
            if (health <= 0)
            {
                speed = 0;
                effect = 0;
                ik++;
                PlayerPrefs.SetInt("Coins", coins);
                SceneManager.LoadScene(0);
            }
            if (ik > 0)
            {
                ik--;
                temporrr();
                PlayerPrefs.SetInt("Coins", coins);
            }
            if (health > numberOfLives)
            {
                health = numberOfLives;
            }
            if (health >= 1)
            {
                speed = speedModify + 5;
            }
            if (coins > 9999)
            {
                coins = 9999;
            }
            if (coins < 0)
            {
                coins = 0;
            }
            healthT.text = health.ToString();
            coinsT.text = coins.ToString();
            numberOfLivesT.text = numberOfLives.ToString();
            if (weapon == 1)
            {
                knife.SetActive(true);
                sword.SetActive(false);
                swordTwo.SetActive(false);
                javelin.SetActive(false);
                axe.SetActive(false);
                halberd.SetActive(false);
            }
            if (weapon == 2)
            {
                knife.SetActive(false);
                sword.SetActive(true);
                swordTwo.SetActive(false);
                javelin.SetActive(false);
                axe.SetActive(false);
                halberd.SetActive(false);
            }
            if (weapon == 3)
            {
                knife.SetActive(false);
                sword.SetActive(false);
                swordTwo.SetActive(true);
                javelin.SetActive(false);
                axe.SetActive(false);
                halberd.SetActive(false);
            }
            if (weapon == 4)
            {
                knife.SetActive(false);
                sword.SetActive(false);
                swordTwo.SetActive(false);
                javelin.SetActive(true);
                axe.SetActive(false);
                halberd.SetActive(false);
            }
            if (weapon == 5)
            {
                knife.SetActive(false);
                sword.SetActive(false);
                swordTwo.SetActive(false);
                javelin.SetActive(false);
                axe.SetActive(true);
                halberd.SetActive(false);
            }
            if (weapon == 6)
            {
                knife.SetActive(false);
                sword.SetActive(false);
                swordTwo.SetActive(false);
                javelin.SetActive(false);
                axe.SetActive(false);
                halberd.SetActive(true);
            }
            if (cloakGravity == 1)
            {
                rb.gravityScale = 0.5f;
            }
            else
            {
                rb.gravityScale = 1f;
            }
            if (speedyBoots == 1)
            {
                speedModify = 5f;
            }
            else
            {
                speedModify = 0f;
            }
            if (healthStaff == 1)
            {
                effect = 1;
            }
            else
            {
                effect = 0;
            }
            //if(fireStaff == 1)
            //{
            //    fire.SetActive(true);
            //}
        }
        else
        {
            transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            moveInput = Input.GetAxis("Horizontal");
            StartCamera.transform.position += new Vector3(moveInput / 10, 0, 0);
            if (Input.GetMouseButtonDown(0))
            {
                start = true;
                //Time.timeScale = 1;
                StartCamera.SetActive(false);
                PlayerCamera.SetActive(true);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        startfireball.offset = -startfireball.offset;
    }

    void temporrr()
    {
        if(weapon != 1)
        {
            if(coins < 100)
                {
                    coins = coins - 5;
                }
                if(coins >= 100)
                {
                    coins = coins - 10;
                    if(coins >= 300)
                    {
                        coins = coins - 20;
                        if(coins >= 500)
                        {
                            coins = coins - 20;
                            if(coins >= 800)
                            {
                                coins = coins - 30;
                                if(coins >= 1000)
                                {
                                    coins = coins - 20;
                                    if(coins >= 2000)
                                    {
                                        coins = coins - 100;
                                        if(coins >= 5000)
                                        {
                                            coins = coins - 300;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
        }
    }   

    void load()
    {
        health = PlayerPrefs.GetInt("Health");
        numberOfLives = PlayerPrefs.GetInt("NumberOfLives");
        coins = PlayerPrefs.GetInt("Coins");
        weapon = PlayerPrefs.GetInt("Weapon");
        amuletOfWater = PlayerPrefs.GetInt("AmuletOfWater");
        amuletOfPoison = PlayerPrefs.GetInt("AmuletOfPoison");
        cloakGravity = PlayerPrefs.GetInt("CloakGravity");
        fireStaff = PlayerPrefs.GetInt("FireStaff");
        healthStaff = PlayerPrefs.GetInt("HealthStaff");
        speedyBoots = PlayerPrefs.GetInt("SpeedyBoots");
        snakeBoss = PlayerPrefs.GetInt("SnakeBoss");
        soul = PlayerPrefs.GetInt("Soul");
        karma = PlayerPrefs.GetInt("Karma");
        mooshrom = PlayerPrefs.GetInt("Mooshrom");
        ik = PlayerPrefs.GetInt("Ik");
        scorpBoss = PlayerPrefs.GetInt("ScorpBoss");
        questNistein = PlayerPrefs.GetInt("QuestNistein");
        nistein = PlayerPrefs.GetInt("Nistein");
    }

    void save()
    {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("NumberOfLives", numberOfLives);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Weapon", weapon);
        PlayerPrefs.SetInt("AmuletOfWater", amuletOfWater);
        PlayerPrefs.SetInt("AmuletOfPoison", amuletOfPoison);
        PlayerPrefs.SetInt("CloakGravity", cloakGravity);
        PlayerPrefs.SetInt("FireStaff", fireStaff);
        PlayerPrefs.SetInt("HealthStaff", healthStaff);
        PlayerPrefs.SetInt("SpeedyBoots", speedyBoots);
        PlayerPrefs.SetInt("SnakeBoss", snakeBoss);
        PlayerPrefs.SetInt("Soul", soul);
        PlayerPrefs.SetInt("Karma", karma);
        PlayerPrefs.SetInt("Mooshrom", mooshrom);
        PlayerPrefs.SetInt("Ik", ik);
        PlayerPrefs.SetInt("ScorpBoss", scorpBoss);
        PlayerPrefs.SetInt("QuestNistein", questNistein);
        PlayerPrefs.SetInt("Nistein", nistein);
    }

    public void OnAttack()
    {
        test = 1;
        Invoke(nameof(EndAttack), _attackSpeed);
    }

    private void EndAttack()
    {
        attack = false;
    }

    void OnTriggerEnter2D(Collider2D bgM)
    {
        if (bgM.gameObject.tag == "openmap")
        {
            map.SetActive(true);
        }
        if (bgM.gameObject.tag == "heart")
        {
            health = health + 1;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "coin")
        {
            coins = coins + 1;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "coin2")
        {
            coins = coins + 2;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "damage")
        {
            health = health - 1;
            Instantiate(damageEffects, transform.position, Quaternion.identity);
        }
        if(bgM.gameObject.tag == "death")
        {
            Instantiate(damageEffects, transform.position, Quaternion.identity);
            health = 0;
        }
        if(bgM.gameObject.tag == "bagofcoin")
        {
            coins = coins + 100;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "soul")
        {
            soul++;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "damage2")
        {
            health = health - 2;
            Instantiate(damageEffects, transform.position, Quaternion.identity);
        }
        if(bgM.gameObject.tag == "aowater")
        {
            amuletOfWater++;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "key")
        {
            bossKey++;
            Destroy(bgM.gameObject);
        }
        if(bgM.gameObject.tag == "quest2")
        {
            questNistein = 1;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "stairs" && jumpInput >= .5f)
        {
            jumpForce = 0;
            transform.position = new Vector2(transform.position.x, transform.position.y + 6.5f);
            jumpForce = temp;
        }
        if(other.gameObject.tag == "down" && jumpInput <= -.7f)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 1.5f);
        }
        if(other.gameObject.tag == "stairs2" && jumpInput >= .5f)
        {
            jumpForce = 0;
            transform.position = new Vector2(transform.position.x, transform.position.y + 4f);
            jumpForce = temp;
        }
    }

    public void tp()
    {
        transform.position = new Vector2(-1, 36);
    }

    public void tp1()
    {
        transform.position = new Vector2(-23, 18);
    }

    public void tp2()
    {
        transform.position = new Vector2(-40, 0);
    }

    public void bossloc()
    {
        transform.position = new Vector2(-228, -48);
    }

    public void cave00()
    {
        transform.position = new Vector2(198, -69);
    }

    public void cave01()
    {
        transform.position = new Vector2(283, 0);
    }

    public void bossloc00()
    {
        if(bossKey == 1){
            transform.position = new Vector2(321, -155.5f);
        }
        else{
            notAllow.SetActive(true);
        }
    }

    public void closenotallow()
    {
        notAllow.SetActive(false);
    }

    public void bossloc01()
    {
        transform.position = new Vector2(389, -69);
    }

    public void cave10()
    {
        transform.position = new Vector2(192.5f, -150);
    }

    public void cave11()
    {
        transform.position = new Vector2(380.5f, -69);
    }

    public void nistein0()
    {
        transform.position = new Vector2(370, -5.5f);
    }

    public void nistein1()
    {
        transform.position = new Vector2(385, -69);
    }

    public void closemap()
    {
        map.SetActive(false);
    }

    void fix()
    {
        StartCoroutine(HealthEffect());
    }

    IEnumerator HealthEffect()
    {
        while (true)
        {
            health += effect;
            yield return new WaitForSeconds(20);
        }
    }
}
