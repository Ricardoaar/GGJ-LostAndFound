using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenWithRequirement : MonoBehaviour
{
    [SerializeField] private int quantityNecessary;
    [SerializeField] private float openDistance;
    [SerializeField] private SpriteRenderer sprite;
    private List<Collider2D> _doorColliders = new List<Collider2D>();
    [SerializeField] private ParticleSystem doorParticles;

    private void Awake()
    {
        _doorColliders = GetComponents<Collider2D>().ToList();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;


        if (BounceStats.SingleInstance.keys >= quantityNecessary && PlayerNear())
        {
            OpenRoad();
        }
    }

    private bool PlayerNear()
    {
        return Mathf.Abs(transform.position.x - BounceStats.SingleInstance.transform.position.x) < openDistance;
    }


    private void OpenRoad()
    {
        sprite.enabled = false;
        foreach (var door in _doorColliders)
        {
            door.enabled = false;
        }

        doorParticles.Play();
        GetComponents<Collider2D>();
        //TODO:OpenGameObject
    }
}