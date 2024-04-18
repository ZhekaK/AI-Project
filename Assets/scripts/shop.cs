using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public player player;
    public GameObject weapons;
    public GameObject specialItems;
    public GameObject noMoney;
    public GameObject shopC;

    public void ChangeOnWeapon()
    {
        weapons.SetActive(true);
        specialItems.SetActive(false);
    }

    public void ChangeOnSpecial()
    {
        specialItems.SetActive(true);
        weapons.SetActive(false);
    }

    public void NoMoneyClose()
    {
        noMoney.SetActive(false);
    }

    public void BuySword()
    {
        if(player.coins >= 300 && player.weapon != 2){
            player.weapon = 2;
            player.coins = player.coins - 300;
            shopC.SetActive(false);
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySwordTwo()
    {
        if(player.coins >= 600 && player.weapon != 3){
            player.weapon = 3;
            player.coins = player.coins - 600;
            shopC.SetActive(false);
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuyJavelin()
    {
        if(player.coins >= 800 && player.weapon != 4){
            player.weapon = 4;
            player.coins = player.coins - 800;
            shopC.SetActive(false);
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuyAxe()
    {
        if(player.coins >= 1000 && player.weapon != 5){
            player.weapon = 5;
            player.coins = player.coins - 1000;
            shopC.SetActive(false);
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuyHalberd()
    {
        if(player.coins >= 2000 && player.weapon != 6){
            player.weapon = 6;
            player.coins = player.coins - 2000;
            shopC.SetActive(false);
        }
        else{
            noMoney.SetActive(true);
        }
    }

    public void BuySpecialOne()
    {
        if(player.coins >= 500 && player.amuletOfWater != 1){
            player.amuletOfWater = 1;
            player.coins = player.coins - 500;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialTwo()
    {
        if(player.coins >= 1000 && player.amuletOfPoison != 1){
            player.amuletOfPoison = 1;
            player.coins = player.coins - 1000;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialThree()
    {
        if(player.coins >= 1250 && player.cloakGravity != 1){
            player.cloakGravity = 1;
            player.speedyBoots = 0;
            player.healthStaff = 0;
            player.fireStaff = 0;
            player.coins = player.coins - 1250;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialFour()
    {
        if(player.coins >= 3000 && player.fireStaff != 1){
            player.cloakGravity = 0;
            player.speedyBoots = 0;
            player.healthStaff = 0;
            player.fireStaff = 1;
            player.coins = player.coins - 3000;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialFive()
    {
        if(player.coins >= 2000 && player.healthStaff != 1){
            player.cloakGravity = 0;
            player.speedyBoots = 0;
            player.healthStaff = 1;
            player.fireStaff = 0;
            player.coins = player.coins - 2000;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialSix()
    {
        if(player.coins >= 800 && player.speedyBoots != 1){
            player.cloakGravity = 0;
            player.speedyBoots = 1;
            player.healthStaff = 0;
            player.fireStaff = 0;
            player.coins = player.coins - 800;
        }
        else{
            noMoney.SetActive(true);
        }
    }
    public void BuySpecialSeven()
    {
        if(player.coins >= 300){
            player.numberOfLives++;
            player.coins = player.coins - 300;
        }
        else{
            noMoney.SetActive(true);
        }
    }
}
