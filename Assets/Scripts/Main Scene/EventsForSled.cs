using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventsForSled : MonoBehaviour
{
    public UnityEvent faced;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            faced.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            faced.Invoke();
        }
    }
    public void Debuging()
    {
        Debug.Log("Hi");
    }
}
