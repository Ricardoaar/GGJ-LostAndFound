using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int quantity;

    public int GetQuantity()
    {
        return quantity;
    }
}