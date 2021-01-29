using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class StaticRotation : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private float turnSeed;
    [SerializeField] private Vector3 direction;

    private void FixedUpdate()
    {
        transform.Rotate(direction * turnSeed);
    }
}