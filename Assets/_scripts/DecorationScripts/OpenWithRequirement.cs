using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OpenWithRequirement : MonoBehaviour
{
    [SerializeField] private int quantityNecessary;
    [SerializeField] private float openDistance;
    [SerializeField] private SpriteRenderer sprite;
    private List<Collider2D> _doorColliders = new List<Collider2D>();
    [SerializeField] private GameObject doorParticles;
    [SerializeField] private AudioClip openClip;

    private void Awake()
    {
        _doorColliders = GetComponents<Collider2D>().ToList();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;


        if (BounceStats.SingleInstance.keys >= quantityNecessary)
        {
            OpenRoad();
        }
    }


    private void OpenRoad()
    {
        gameObject.SetActive(false);
        foreach (var door in _doorColliders)
        {
            door.enabled = false;
        }

        SfxManager.SingleInstance.PlaySound(openClip);
        Instantiate(doorParticles, transform.position, Quaternion.identity);
    }
}