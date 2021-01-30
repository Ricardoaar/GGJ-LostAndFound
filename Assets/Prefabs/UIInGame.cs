using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keys;
    [SerializeField] private List<Image> lifesImages, maskImages = new List<Image>();
    [SerializeField] private List<Sprite> maskSprites = new List<Sprite>();
    [SerializeField] private Sprite activeLifeImg, inactiveLifeImage;


    public static UIInGame SingleInstance;

    private void Awake()
    {
        SingleInstance = this;
    }


    public void ChangeMaskImage()
    {
        var maskGained = LevelManager.SingleInstance.GetLvlsCompleted();

        for (var i = 0; i < maskGained; i++)

        {
            maskImages[i].sprite = maskSprites[i];
        }
    }


    private void OnEnable()
    {
        BounceController.OnPlayerDamage += ChangeLifeStateOnPlayerDamage;
    }

    private void OnDisable()
    {
        BounceController.OnPlayerDamage -= ChangeLifeStateOnPlayerDamage;
    }

    private void ChangeLifeStateOnPlayerDamage(float time)
    {
        ChangeLifes(BounceStats.SingleInstance.currentPlayerLife);
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