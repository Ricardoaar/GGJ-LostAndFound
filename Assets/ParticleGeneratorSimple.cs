using System;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ParticleGeneratorSimple : MonoBehaviour
{
    [SerializeField] private ParticlePool pool;

    [SerializeField] private float spawnRate;
    private GameObject _currentObject;
    private float _posYToSpawn;


    private void Awake()
    {
        InvokeRepeating(nameof(SpawnParticle), 0, spawnRate);
    }


    private void SpawnParticle()
    {
        var obj = pool.ExtractFromQueue();
        obj.transform.position = transform.position;

        obj.SetActive(true);
    }
}