using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class chimneyController : MonoBehaviour
{
    private int presentAmount = 0;
    public TextMeshProUGUI presentAmountText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "present")
        {
            Destroy(collision.gameObject);
            presentAmount++;
            presentAmountText.text = presentAmount.ToString();
        }
    }
}
