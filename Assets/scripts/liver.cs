using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liver : MonoBehaviour
{
    public int off;
    public GameObject buttonoff;
    public Animator anim;
    public Animator animl;

    void Start()
    {
        off = PlayerPrefs.GetInt("Off");
    }

    void Update()
    {
        if(off >= 1)
        {
            buttonoff.SetActive(false);
            animl.SetBool("liver", true);
        }
        PlayerPrefs.SetInt("Off", off);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            anim.SetBool("triggered", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetBool("triggered", false);
        }
    }

    public void offf()
    {
        off = 1;
        animl.SetBool("liver", true);
    }
}
