﻿using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(500)]
public class UIInGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keys;
    [SerializeField] private List<Image> lifesImages = new List<Image>();
    [SerializeField] private List<Sprite> maskSprites = new List<Sprite>();
    [SerializeField] private Image maskImage;
    [SerializeField] private Sprite activeLifeImg, inactiveLifeImage;
    [SerializeField] private GameObject gameOverPanel;

    public static UIInGame SingleInstance;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        if (SingleInstance == null)
        {
            SingleInstance = this;
        }
    }


    private void Start()
    {
        ChangeLifes(BounceStats.SingleInstance.GetPlayerLife());
        ChangeMaskImage();
    }

    private void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }


    public void ChangeMaskImage()
    {
        var maskGained = LevelManager.SingleInstance.GetLevelsSum().Sum();

        switch (maskGained)
        {
            case 0:
                maskImage.sprite = maskSprites[0];
                break;
            case 1:
                maskImage.sprite = maskSprites[1];
                break;
            case 3:
                maskImage.sprite = maskSprites[2];
                break;
            case 4:
                maskImage.sprite = maskSprites[3];
                break;
            case 6:
                maskImage.sprite = maskSprites[4];
                break;
            case 10:
                maskImage.sprite = maskSprites[5];
                break;
        }
    }


    private void OnEnable()
    {
        BounceController.OnPlayerDamage += ChangeLifeStateOnPlayerDamage;
        GameManager.OnGameOver += OnGameOver;
        BounceStats.OnMaskCollect += ChangeMaskImage;
    }

    private void OnDisable()
    {
        BounceController.OnPlayerDamage -= ChangeLifeStateOnPlayerDamage;
        GameManager.OnGameOver -= OnGameOver;
        BounceStats.OnMaskCollect -= ChangeMaskImage;

        SingleInstance = null;
    }

    private void ChangeLifeStateOnPlayerDamage(float time)
    {
        ChangeLifes(BounceStats.SingleInstance.GetPlayerLife());
    }

    private void ChangeLifes(int num)
    {
        int i;
        for (i = 0; i < num; i++)
        {
            lifesImages[i].sprite = activeLifeImg;
        }

        for (; i < lifesImages.Count; i++)
        {
            lifesImages[i].sprite = inactiveLifeImage;
        }
    }
}