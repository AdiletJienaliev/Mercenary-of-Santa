using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;


public class DialogController : MonoBehaviour
{
    public List<DialogItem> Dialog = new List<DialogItem>();
    [Header("Dialog items")]
    public TextMeshProUGUI phraseText;
    public TextMeshProUGUI nameText;
    private GameObject DialogMainObj;
    private void Start()
    {
        DialogMainObj = gameObject;
        NextPhrase();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stoper)
        {
            stoper = false;
            NextPhrase();
        }
    }
    int currentIndex = 0;
    bool stoper = true;
    private void NextPhrase()
    {
        if (currentIndex < Dialog.Count)
        {
            if (PlayerPrefs.GetInt("Localization") == 0)
            {
                stoper = true;
                if (Dialog[currentIndex].Name != null)
                {
                    nameText.text = Dialog[currentIndex].Name;
                }
                if (Dialog[currentIndex].Text != null)
                    phraseText.text = Dialog[currentIndex].Text;
                Dialog[currentIndex].afterPhrase.Invoke();
                if (currentIndex != (Dialog.Count - 1))
                {
                    StartCoroutine(shake());
                }
                currentIndex++;
            }
            else
            {
                stoper = true;
                if (Dialog[currentIndex].Name_Eng != null)
                {
                    nameText.text = Dialog[currentIndex].Name_Eng;
                }
                if (Dialog[currentIndex].Text_Eng != null)
                    phraseText.text = Dialog[currentIndex].Text_Eng;
                Dialog[currentIndex].afterPhrase.Invoke();
                if (currentIndex != (Dialog.Count - 1))
                {
                    StartCoroutine(shake());
                }
                
                currentIndex++;
            }
        }
        else
        {
            Dialog[currentIndex].afterPhrase.Invoke();
            /*Destroy(DialogMainObj);*/
        }
    }
    private IEnumerator shake()
    {
        LeanTween.move(DialogMainObj, new Vector3(DialogMainObj.transform.position.x, DialogMainObj.transform.position.y - 50, DialogMainObj.transform.position.z), 0.2f);
        yield return new WaitForSeconds(0.2f);
        LeanTween.move(DialogMainObj, new Vector3(DialogMainObj.transform.position.x, DialogMainObj.transform.position.y + 50, DialogMainObj.transform.position.z), 0.2f);
        yield return new WaitForSeconds(0.2f);
    }
}
[System.Serializable]
public class DialogItem
{
    [Header("Rus")]
    public string Text;
    public string Name;  
    [Header("Eng")]
    public string Text_Eng;
    public string Name_Eng;

    public UnityEvent afterPhrase;
}
