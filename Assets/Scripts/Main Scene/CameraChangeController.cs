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
    private void Update()
    {
        InputkeyBoard();
    }
    private void InputkeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            maincam.SetActive(false);
            leftcam.SetActive(false);
            rightcam.SetActive(false);
            upcam.SetActive(true);
            backcam.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            maincam.SetActive(false);
            leftcam.SetActive(true);
            rightcam.SetActive(false);
            upcam.SetActive(false);
            backcam.SetActive(false);
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
            }
            else
            {
                maincam.SetActive(true);
                leftcam.SetActive(false);
                rightcam.SetActive(false);
                upcam.SetActive(false);
                backcam.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            maincam.SetActive(false);
            leftcam.SetActive(false);
            rightcam.SetActive(true);
            upcam.SetActive(false);
            backcam.SetActive(false);
        }
    }
    private void ZeroingRotation()
    {
        maincam.transform.rotation = Quaternion.identity;
        leftcam.transform.rotation = Quaternion.identity;
        rightcam.transform.rotation = Quaternion.identity;
        upcam.transform.rotation = Quaternion.identity;
        backcam.transform.rotation = Quaternion.identity;
    }
}
