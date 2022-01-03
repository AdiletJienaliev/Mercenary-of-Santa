using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region private field
    private float mouseX;
    private float mouseY;
    private float rotationY;
    private float rotationX;
    private Transform myTransform;
    [Header("настройки ограничения камеры")]
    [SerializeField]private float Ymin;
    [SerializeField] private float Ymax;
    [SerializeField] private float Xmin;
    [SerializeField] private float Xmax;
    private RaycastHit hit;
    private bool giftCaptured = false;
    private GameObject presentGO;
    #endregion
    #region public field
    [Header("Контроль чувствительности мыши")]
    public float sensitivityMouse = 200f;
    public Transform playerTransform;
    [Header("Обьект гдк будет появлятся подарок ")]
    [SerializeField] private Transform presentsPos;
    [Header("Компоненты необходимые для спавна подарков")]
    public GameObject present;
    public Transform presentSpawnPos;

    #endregion
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        InputMouse();
        CameraRotate();
        RayPickUp();
        if (Input.GetMouseButtonDown(0) && giftCaptured)
        {
            Rigidbody presentRig= presentGO.GetComponent<Rigidbody>();
            presentRig.constraints = RigidbodyConstraints.None;
            presentRig.AddForce(Vector3.forward*20, ForceMode.Impulse);
            giftCaptured = false;
            presentGO.transform.SetParent(playerTransform.parent);
        }
    }
    private void InputMouse()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivityMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivityMouse * Time.deltaTime;
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, Ymin, Ymax);
        rotationX -= mouseX;
        rotationX = Mathf.Clamp(rotationX, Xmin, Xmax);
    }
    private void CameraRotate()
    {
        playerTransform.localRotation = Quaternion.Euler( 0, -rotationX, 0);
        myTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);
    }
    
    private void RayPickUp()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.tag == "present")
            {
                hit.transform.SetParent(presentsPos);
                LeanTween.moveLocal(hit.transform.gameObject, new Vector3(0, 0, 0),0.2f);
                giftCaptured = true;
                presentGO = hit.transform.gameObject;
                GameObject a=  Instantiate(present);
                a.transform.SetParent(presentSpawnPos);
                a.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}

