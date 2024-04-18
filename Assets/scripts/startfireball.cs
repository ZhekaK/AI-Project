using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class startfireball : MonoBehaviour
{
    public GameObject fireBall;
    public Transform shotPoint;
    public Button startFb;
    public float offset;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, offset);
    }

    public void shoot()
    {
        Invoke("flyfb", 1);
        startFb.interactable = false;
    }

    void flyfb()
    {
        Instantiate(fireBall, shotPoint.position, transform.rotation);
        startFb.interactable = true;
    }
}
