using UnityEngine;

public class MaskCollectable : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private ParticleSystem collectParticle;
    public int getId => id;

    private void OnEnable()
    {
        BounceStats.OnMaskCollect += OnMaskCollect;
    }

    private void OnDisable()
    {
        BounceStats.OnMaskCollect -= OnMaskCollect;
    }

    private void OnMaskCollect()
    {
        Instantiate(collectParticle, transform.position, Quaternion.Euler(Vector3.zero));
    }
}