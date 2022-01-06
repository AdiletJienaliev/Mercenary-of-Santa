using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRotate : MonoBehaviour
{
    [SerializeField] private int dir = 1;
    [SerializeField] private float time = 5;

    void OnEnable()
    {
        LeanTween.rotateAroundLocal(gameObject, Vector3.forward, 360 * dir, time).setEase(easeType: LeanTweenType.linear).setLoopClamp();
    }
}
