using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Timeline;

public class GameController : MonoBehaviour
{
    private static int hitAmount = 0;
    [Header("Количество попаданий необходимое для прохождения")]
    public int needHitAmount;
    private static int _needHitAmount;
    public static int HitAmount
    {
        get
        {
            return hitAmount;
        }
        set
        {
            hitAmount = value;
            _hitAmountText.text = value.ToString() + "/" + _needHitAmount.ToString();
        }
    }
    public TextMeshProUGUI hitAmountText;
    public static TextMeshProUGUI _hitAmountText;
    [Header("Сани")]
    public GameObject Sled;
    public float speedForUp;
    public float speedForMovefoward;
    [Header("Ограничения позиции")]
    public float MinY;
    public float MaxY;
    public static bool Mainpos = true;
    [Header("Time lime ogj")]
    public GameObject TimeLine;

    private Transform SledTransform;
    [Header("Win Events")]
    public UnityEvent Win;
    [Header("KeyBoard restart finish")]
    public GameObject restartBtn;
    [Header("Pause Active")]
    public GameObject PausePan;
    public GameObject clueGroup;
    [Header("Pause / Resume")]
    public UnityEvent pause;
    public UnityEvent resume;

    private void Start()
    {
        _needHitAmount = needHitAmount;
        _hitAmountText = hitAmountText;
        hitAmount = 0;
        SledTransform = Sled.GetComponent<Transform>();
        TimeLine.SetActive(false);
        _hitAmountText.text = 0.ToString() + "/" + _needHitAmount.ToString();
    }
    private bool SimpleBool = true;
    public static bool canMove = true;
    private void Update()
    {
        InputKeyBoard();
        if (HitAmount != 0 && canMove)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y, SledTransform.position.z + speedForMovefoward * Time.deltaTime);
            if (SimpleBool)
            {
                TimeLine.SetActive(true);
                SimpleBool = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePan.SetActive(!PausePan.activeSelf);
            if (PausePan.activeSelf)
            {
                canMove = false;
                Cursor.lockState = CursorLockMode.None;
                pause.Invoke();
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                canMove = true;
                resume.Invoke();
            }
        }
    }

    private void InputKeyBoard()
    {
        if (Input.GetKey(KeyCode.LeftShift) && SledTransform.position.y <= MaxY && Mainpos)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y + speedForUp * Time.deltaTime, SledTransform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftControl) && SledTransform.position.y >= MinY && Mainpos)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y - speedForUp * Time.deltaTime, SledTransform.position.z);
        }
    }
    public void Finish()
    {
        if (hitAmount !>= needHitAmount)
        {
            restartBtn.SetActive(true);
        }
        else
        {
            Win.Invoke();
        }
    }
    public void WinScene()
    {
        PlayerPrefs.SetInt("PlayWithoutCutSceneBtn", 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
    #region PauseBtn
    public void ResumeBtn()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PausePan.SetActive(false);
        canMove = true;
        resume.Invoke();
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void ExitInMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SensitivitySettingSlider(float value)
    {
        CameraController.sensitivityMouse = value;
    }
    public void ClueAtcive()
    {
        clueGroup.SetActive(!clueGroup.activeSelf);
    }
    #endregion
}
