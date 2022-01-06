using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteScreen : MonoBehaviour
{
    private void Start()
    {
        AlphaIn();
    }

    public void AlphaIn()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1, 0);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0, 0.5f);
    }

    public void AlphaOut()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0, 0);
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 1, 0.5f);
    }
}
