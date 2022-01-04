using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum BehaviourState
{
    badChild = 0,
    goodchild = 1,
    without = 2
}
public class chimneyController : MonoBehaviour
{
    public BehaviourState behaviourState;
    public Outline outline;
    public Outline chimney;
    public GameObject icon;
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        switch ((int)behaviourState)
        {
            case 0:
                if (other.gameObject.tag == "coal")
                {
                    GameController.HitAmount++;
                    Debug.Log("Поадание");
                    Destroy(other.gameObject);
                    outline.enabled = false;
                    chimney.enabled = false;
                    icon.SetActive(false);
                }
                break;
            case 1:
                if (other.gameObject.tag == "present")
                {
                    GameController.HitAmount++;
                    Debug.Log("Поадание");
                    Destroy(other.gameObject);
                    outline.enabled = false;
                    chimney.enabled = false;
                    icon.SetActive(false);
                }
                break;
        }
        
        
    }
}
