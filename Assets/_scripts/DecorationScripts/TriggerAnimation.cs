using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private String animationName;
    [SerializeField] private InteractiveObject script;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        script.OnInteractiveActive += ActiveTrigger;
    }

    private void OnDisable()
    {
        script.OnInteractiveActive -= ActiveTrigger;
    }

    private void ActiveTrigger()
    {
        _animator.SetTrigger(animationName);
    }
}