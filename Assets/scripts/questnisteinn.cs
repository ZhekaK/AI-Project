using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questnisteinn : MonoBehaviour
{
    public player player;
    public GameObject helpN;
    public liver liver;
    public GameObject nistein;
    public GameObject zapiska;

    void Update()
    {
        if(player.questNistein >= 1)
        {
            helpN.SetActive(true);
        }
        else
        {
            helpN.SetActive(false);
        }
        if(player.nistein == 1)
        {
            nistein.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if(liver.off == 1)
            {
                zapiska.SetActive(true);
                player.karma++;
                player.nistein++;
                player.coins = player.coins + 300;
                liver.off++;
            }
        }
    }

    public void closez()
    {
        zapiska.SetActive(false);
    }
}