using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Button reloadSceneButton;
    [SerializeField] private Button resetGameButton;

    [SerializeField] private patrulEnemy[] enemies;
    [SerializeField] private Text[] npcInfo;

    private player player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player>();
        reloadSceneButton.onClick.AddListener(reloadScene);
        resetGameButton.onClick.AddListener(resetGame);
    }

    private void Update()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            npcInfo[i].text = "ID: " + enemies[i].mobID +
                Environment.NewLine + "Обнаружений слева: " + enemies[i].left +
                Environment.NewLine + "Обнаружений справа: " + enemies[i].right +
                Environment.NewLine + "Направление: " + enemies[i].direction.ToString() +
                Environment.NewLine + "Первое обнаружение?: " + enemies[i].firstDetection.ToString();
        }
    }

    public void resetGame()
    {
        player.RESET_GAME = true;
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
