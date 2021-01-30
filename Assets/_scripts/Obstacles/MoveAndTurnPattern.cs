using UnityEngine;

public class MoveAndTurnPattern : MonoBehaviour
{
    [SerializeField] private Transform maxPos, minPos;
    [SerializeField] private MoveOneDirection positive, negative;
    [SerializeField] private bool startToPositive;

    private void Awake()
    {
        positive.enabled = startToPositive;
        negative.enabled = !startToPositive;
    }

    private void Update()
    {
        if (positive.enabled && transform.position.x >= maxPos.position.x)
        {
            positive.enabled = false;
            negative.enabled = true;
        }
        else if (negative.enabled && transform.position.x <= minPos.transform.position.x)
        {
            negative.enabled = false;
            positive.enabled = true;
        }
    }
}