using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogyes : MonoBehaviour
{
    public pickup pickup;
    public GameObject dialogok;
    public GameObject cong;
    public player player;
    public GameObject mooshromm;
    public GameObject korzina;
    public GameObject itemformission;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if(pickup.yes == 1)
        {
            dialogok.SetActive(true);
        }
        else{
            dialogok.SetActive(false);
        }
        if(player.mooshrom == 1)
        {
            mooshromm.SetActive(false);
            korzina.SetActive(false);
        }
    }

    public void check()
    {
        if(pickup.yes == 1)
        {
            cong.SetActive(true);
            player.karma++;
            player.mooshrom++;
            player.coins = player.coins + 100;
        }
    }
    public void closec()
    {
        cong.SetActive(false);
        mooshromm.SetActive(false);
    }
}
