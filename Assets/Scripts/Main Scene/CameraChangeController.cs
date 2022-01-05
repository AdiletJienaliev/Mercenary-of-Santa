using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerPos
{
    up,
    main,
    left,
    right,
    back
}
public class CameraChangeController : MonoBehaviour
{
    [Header("все камеры ")]
    public GameObject maincam;
    public GameObject leftcam;
    public GameObject rightcam;
    public GameObject upcam;
    public GameObject backcam;
    [Header("Доступные кнопки")]
    public GameObject W;
    public GameObject A;
    public GameObject S;
    public GameObject D;
    public GameObject shift;
    public GameObject ctrl;
    private void Start()
    {
        W.SetActive(true);
        A.SetActive(true);
        S.SetActive(true);
        D.SetActive(true);
    }
    private void Update()
    {
        InputkeyBoard();
    }
    private void InputkeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (maincam.activeSelf == true && leftcam.activeSelf == false && rightcam.activeSelf == false
                && upcam.activeSelf == false && backcam.activeSelf == false)
            {
                maincam.SetActive(false);
                leftcam.SetActive(false);
                rightcam.SetActive(false);
                upcam.SetActive(true);
                backcam.SetActive(false);
                W.SetActive(false);
                A.SetActive(false);
                S.SetActive(true);
                D.SetActive(false);
                ctrl.SetActive(false);
                shift.SetActive(false);
                GameController.Mainpos = false;
                CameraController.canTrow = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (maincam.activeSelf == true && leftcam.activeSelf == false && rightcam.activeSelf == false
                && upcam.activeSelf == false && backcam.activeSelf == false)
            {
                maincam.SetActive(false);
                leftcam.SetActive(true);
                rightcam.SetActive(false);
                upcam.SetActive(false);
                backcam.SetActive(false);
                W.SetActive(false);
                A.SetActive(false);
                S.SetActive(true);
                D.SetActive(false);
                ctrl.SetActive(false);
                shift.SetActive(false);
                GameController.Mainpos = false;
                CameraController.canTrow = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (maincam.activeSelf == true && leftcam.activeSelf == false && rightcam.activeSelf == false
                && upcam.activeSelf == false && backcam.activeSelf == false)
            {
                maincam.SetActive(false);
                leftcam.SetActive(false);
                rightcam.SetActive(false);
                upcam.SetActive(false);
                backcam.SetActive(true);
                W.SetActive(false);
                A.SetActive(false);
                S.SetActive(true);
                D.SetActive(false);
                ctrl.SetActive(false);
                shift.SetActive(false);
                GameController.Mainpos = false;
                CameraController.canTrow = false;
            }
            else
            {
                GameController.Mainpos = true;
                maincam.SetActive(true);
                leftcam.SetActive(false);
                rightcam.SetActive(false);
                upcam.SetActive(false);
                backcam.SetActive(false);
                W.SetActive(true);
                A.SetActive(true);
                S.SetActive(true);
                D.SetActive(true);
                ctrl.SetActive(true);
                shift.SetActive(true);
                CameraController.canTrow = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (maincam.activeSelf == true && leftcam.activeSelf == false && rightcam.activeSelf == false
                && upcam.activeSelf == false && backcam.activeSelf == false)
            {
                maincam.SetActive(false);
                leftcam.SetActive(false);
                rightcam.SetActive(true);
                upcam.SetActive(false);
                backcam.SetActive(false);
                W.SetActive(false);
                A.SetActive(false);
                S.SetActive(true);
                D.SetActive(false);
                ctrl.SetActive(false);
                shift.SetActive(false);
                GameController.Mainpos = false;
                CameraController.canTrow = true;
            }
        }
    }
    public void Fihish()
    {
        maincam.SetActive(false);
        leftcam.SetActive(false);
        rightcam.SetActive(false);
        upcam.SetActive(false);
        backcam.SetActive(false);
        W.SetActive(false);
        A.SetActive(false);
        S.SetActive(true);
        D.SetActive(false);
        ctrl.SetActive(false);
        shift.SetActive(false);
    }
}
