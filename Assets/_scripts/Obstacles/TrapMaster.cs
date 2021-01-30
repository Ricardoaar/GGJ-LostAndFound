using System;
using UnityEngine;

public class TrapMaster : InteractiveObject
{
    public Action OnTrapUp;
    public bool canActiveTrap;

    private void Awake()
    {
        canActiveTrap = true;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || !canActiveTrap) return;
        canActiveTrap = false;

        OnInteractiveActive?.Invoke();
    }
}