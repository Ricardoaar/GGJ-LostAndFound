using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    protected Queue<GameObject> _objects = new Queue<GameObject>();

    public int id;

    //Prefab which contains all components of the object to instance
    [SerializeField] protected GameObject prefab;

    [SerializeField] protected int amount;

    private void Awake()
    {
        FillQueue();
    }

    /// <summary>
    /// Instance a game object and make changes in itself
    /// </summary>
    /// <returns>The game object instanced</returns>
    protected virtual GameObject CreateObj()
    {
        var obj = Instantiate(prefab);

        obj.SetActive(false);

        return obj;
    }

    /// <summary>
    /// Fill the  queue
    /// </summary>
    private void FillQueue()
    {
        for (var i = 0; i < amount; i++)
        {
            EnqueueObj(CreateObj());
        }
    }

    /// <summary>
    /// Return an object of the pool, if the pool is almost empty is filled again
    /// </summary>
    /// <returns></returns>
    public GameObject ExtractFromQueue()
    {
        if (_objects.Count < 4)
        {
            FillQueue();
        }

        var obj = _objects.Dequeue();
        return obj;
    }

    /// <summary>
    /// Return and obj to the que
    /// </summary>
    /// <param name="gameObj"></param>
    public void EnqueueObj(GameObject gameObj)
    {
        _objects.Enqueue(gameObj);
    }
}