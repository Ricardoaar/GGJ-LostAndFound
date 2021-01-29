using System;
using UnityEngine;

public class HoleTeletransport : MonoBehaviour
{
    [SerializeField] private Transform destiny;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }
}