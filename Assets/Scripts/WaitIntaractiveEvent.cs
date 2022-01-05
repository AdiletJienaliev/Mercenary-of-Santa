using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WaitIntaractiveEvent : MonoBehaviour
{
    [Header("Main settings")]
    [SerializeField] private KeyCode intaractableKey;

    [Header("Events")]
    [SerializeField] private UnityEvent onEnableEvent;
    [SerializeField] private UnityEvent intaractiveEvent;
    [SerializeField] private bool destroyByIntaract;

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    void Update()
    {
        if (Input.GetKeyDown(intaractableKey))
        {
            intaractiveEvent.Invoke();
            if (destroyByIntaract) Destroy(gameObject);
        }
    }
}
