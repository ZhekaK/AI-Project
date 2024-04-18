using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject inventory;
    bool inventoryOn;
    public player player;
    public GameObject[] weapons;
    public GameObject[] special;

    private void Start()
    {
        inventoryOn = false;
    }

    void Update()
    {
        if(player.weapon == 1){
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);
            weapons[5].SetActive(false);
        }
        if(player.weapon == 2){
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);
            weapons[5].SetActive(false);
        }
        if(player.weapon == 3){
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);
            weapons[5].SetActive(false);
        }
        if(player.weapon == 4){
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(true);
            weapons[4].SetActive(false);
            weapons[5].SetActive(false);
        }
        if(player.weapon == 5){
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(true);
            weapons[5].SetActive(false);
        }
        if(player.weapon == 6){
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
            weapons[4].SetActive(false);
            weapons[5].SetActive(true);
        }
        if(player.amuletOfWater == 1)
        {
            special[0].SetActive(true);
        }
        if(player.amuletOfPoison == 1)
        {
            special[1].SetActive(true);
        }
        if(player.cloakGravity == 1)
        {
            special[2].SetActive(true);
            special[3].SetActive(false);
            special[4].SetActive(false);
            special[5].SetActive(false);
        }
        if(player.fireStaff == 1)
        {
            special[2].SetActive(false);
            special[3].SetActive(true);
            special[4].SetActive(false);
            special[5].SetActive(false);
        }
        if(player.healthStaff == 1)
        {
            special[2].SetActive(false);
            special[3].SetActive(false);
            special[4].SetActive(true);
            special[5].SetActive(false);
        }
        if(player.speedyBoots == 1)
        {
            special[2].SetActive(false);
            special[3].SetActive(false);
            special[4].SetActive(false);
            special[5].SetActive(true);
        }
    }
    
    public void Chest()
    {
        if(inventoryOn == false){
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if(inventoryOn == true){
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}
