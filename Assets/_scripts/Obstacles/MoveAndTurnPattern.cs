using System;
using UnityEngine;

public class MoveAndTurnPattern : MonoBehaviour
{
    [SerializeField] private Transform maxPos, minPos;
    [SerializeField] private MoveOneDirection positive, negative;
    [SerializeField] private bool startToPositive;
    [SerializeField] private DirectionVector directionVector;
    private StaticRotation _rotation;

    private delegate void CheckPosition();

    private CheckPosition _checking;

    private void Awake()
    {
        positive.enabled = startToPositive;
        negative.enabled = !startToPositive;

        _rotation = GetComponentInChildren<StaticRotation>();
    }

    private void Start()
    {
        switch (directionVector)
        {
            case DirectionVector.Up:
            case DirectionVector.Down:
                _checking = AxisYCheck;
                _rotation.ChangeDirection(new Vector3(0, 0, startToPositive ? 1 : -1));
                break;
            case DirectionVector.left:
            case DirectionVector.right:
                _checking = AxisXCheck;
                _rotation.ChangeDirection(new Vector3(0, 0, startToPositive ? 1 : -1));
                break;
            default:

                throw new ArgumentOutOfRangeException();
        }
    }

    private void Update()
    {
        _checking.Invoke();
    }


    private void AxisXCheck()
    {
        if (positive.enabled && transform.position.x >= maxPos.position.x)
        {
            positive.enabled = false;
            negative.enabled = true;
            _rotation.ChangeDirection(new Vector3(0, 0, -1));
        }

        else if (negative.enabled && transform.position.x <= minPos.transform.position.x)
        {
            negative.enabled = false;
            positive.enabled = true;
            _rotation.ChangeDirection(new Vector3(0, 0, 1));
        }
    }

    private void AxisYCheck()

    {
        if (positive.enabled && transform.localPosition.y >= maxPos.localPosition.y)
        {
            positive.enabled = false;
            negative.enabled = true;
            _rotation.ChangeDirection(new Vector3(0, 0, -1));
        }
        else if (negative.enabled && transform.localPosition.y <= minPos.transform.localPosition.y)
        {
            negative.enabled = false;
            positive.enabled = true;
            _rotation.ChangeDirection(new Vector3(0, 0, 1));
        }
    }
}