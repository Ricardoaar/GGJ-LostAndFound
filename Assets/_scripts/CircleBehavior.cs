using System;
using _scripts;
using UnityEngine;

public class CircleBehavior : MonoBehaviour, IBackToQueue
{
    private ObjectPool _pool;
    [SerializeField] private float velocity;
    [SerializeField, Range(0, 10)] private float offsetCameraFinish;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        if (transform.position.x > _camera.transform.position.x + _camera.rect.width / 2 + offsetCameraFinish)
        {
            BackToQueue();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }

    public void SetPool(ObjectPool pool)
    {
        _pool = pool;
    }

    public void BackToQueue()
    {
        _pool.EnqueueObj(gameObject);
        gameObject.SetActive(false);
    }
}