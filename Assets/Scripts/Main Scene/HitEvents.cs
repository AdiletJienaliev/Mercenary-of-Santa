using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum HitTipes
{
    present,
    coal,
    PresentCoal
}
public class HitEvents : MonoBehaviour
{
    public UnityEvent hit;
    public HitTipes hittipes;
    private void OnTriggerEnter(Collider other) 
    {
        switch (hittipes)
        {
            case HitTipes.coal:
                if (other.gameObject.tag == "coal")
                {
                    hit.Invoke();
                }
                break;
            case HitTipes.present:
                if (other.gameObject.tag == "present")
                {
                    hit.Invoke();
                }
                break;
            case HitTipes.PresentCoal:
                if (other.gameObject.tag == "coal" || other.gameObject.tag == "present")
                {
                    hit.Invoke();
                }
                break;
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        switch (hittipes)
        {
            case HitTipes.coal:
                if (other.gameObject.tag == "coal")
                {
                    hit.Invoke();
                }
                break;
            case HitTipes.present:
                if (other.gameObject.tag == "present")
                {
                    hit.Invoke();
                }
                break;
            case HitTipes.PresentCoal:
                if (other.gameObject.tag == "coal" || other.gameObject.tag == "present")
                {
                    hit.Invoke();
                }
                break;
        }

    }
}
