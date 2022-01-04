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
    private void Start()
    {
    }
    public TextMeshProUGUI presentAmountText;
    private void OnTriggerEnter(Collider other)
    {
        switch ((int)behaviourState)
        {
            case 0:
                if (other.gameObject.tag == "coal")
                {
                    GameController.HitAmount++;
                    presentAmountText.text = GameController.HitAmount.ToString();
                    Destroy(other.gameObject);
                }
                break;
            case 1:
                if (other.gameObject.tag == "present")
                {
                    GameController.HitAmount++;
                    presentAmountText.text = GameController.HitAmount.ToString();
                    Destroy(other.gameObject);
                }
                break;
        }
        
        
    }
}
