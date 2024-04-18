using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject shure;
    public GameObject shure2;
    public lvlchanger lvlchanger;

    public void shureone()
    {
        shure.SetActive(true);
        lvlchanger.loadLevel = 1;
        lvlchanger.position = new Vector2(0, -3);
    }
    public void shuretwo()
    {
        shure2.SetActive(true);
        lvlchanger.loadLevel = 2;
        lvlchanger.position = new Vector2(0, 0);
    }
    public void shurethree()
    {
        shure.SetActive(true);
        lvlchanger.loadLevel = 3;
    }

    public void no()
    {
        shure.SetActive(false);
    }

    public void no2()
    {
        shure2.SetActive(false);
    }
}
