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
    #endregion
    #region public field
    [Header("Контроль чувствительности мыши")]
    public float sensitivityMouse = 200f;
    public Transform playerTransform;
    [Header("Обьект гдк будет появлятся подарок ")]
    [SerializeField] private Transform presentsPos;
    public float force;
    #endregion
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        InputMouse();
        CameraRotate();
        RayPickUp();
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
    static public GameObject presentInhand;
    private void RayPickUp()
    {

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (Input.GetKeyDown(KeyCode.E) && hit.transform.gameObject.tag == "Bag"&& presentInhand == null)
            {
                GameObject a = Instantiate<GameObject>(Resources.Load<GameObject>("present"));
                a.transform.SetParent(presentsPos);
                a.transform.localPosition = Vector3.zero;
                presentInhand = a;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (presentInhand != null)
            {
                Rigidbody rig = presentInhand.GetComponent<Rigidbody>();
                rig.AddRelativeForce(new Vector3(Random.Range(-0.07f,0.07f), Random.Range(0.2f, 0.4f), 1) * force, ForceMode.Impulse);
                rig.useGravity = true;
                presentInhand.transform.SetParent(playerTransform.parent.parent);
                presentInhand = null;
            }
        }
    }
}

