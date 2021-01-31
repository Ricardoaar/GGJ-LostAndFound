using System.Collections.Generic;
using _scripts;
using UnityEngine;

public class ParticlePool : ObjectPool
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private float timeToBackParticles = 0;

    protected override GameObject CreateObj()
    {
        var obj = Instantiate(prefab, transform, false);
        obj.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
        var scriptBackTq = obj.GetComponent<BackToQueueAfterTime>();
        scriptBackTq.SetPool(this);
        obj.SetActive(false);
        if (timeToBackParticles != 0)
        {
            scriptBackTq.ChangeTimeToBack(timeToBackParticles);
        }

        return obj;
    }
}