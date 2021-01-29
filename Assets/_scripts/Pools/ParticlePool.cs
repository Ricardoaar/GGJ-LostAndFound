using System.Collections.Generic;
using _scripts;
using UnityEngine;

public class ParticlePool : ObjectPool
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    protected override GameObject CreateObj()
    {
        var obj = Instantiate(prefab, transform, false);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        obj.GetComponent<BackToQueueAfterTime>().SetPool(this);
        obj.SetActive(false);

        return obj;
    }
}