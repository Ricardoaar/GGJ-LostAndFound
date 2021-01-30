using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MaskUpdater : MonoBehaviour
{
    [SerializeField] private Image maskImage;
    [SerializeReference] private List<Sprite> maskSprites = new List<Sprite>();

    private void Start()
    {
        ChangeMaskImage();
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
}