using UnityEngine;

public class MaskCollectable : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private ParticleSystem collectParticle;
    [SerializeField] private AudioClip maskCollectAudio;
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
        SfxManager.SingleInstance.PlaySound(maskCollectAudio);
        Instantiate(collectParticle, transform.position, Quaternion.Euler(Vector3.zero));
    }
}