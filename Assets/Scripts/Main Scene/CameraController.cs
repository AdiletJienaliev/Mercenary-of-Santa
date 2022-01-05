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
    [SerializeField] private float Ymin;
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

    [Header("Лист для подарков")]
    public List<GameObject> presents = new List<GameObject>();

    [Header("Уголь")]
    public List<GameObject> coals = new List<GameObject>();

    [Header("горячая клавишв для подбора")]
    public GameObject hotKeyBoard_E;
    public GameObject hotKeyBoard_Q;
    [Header("Скрипты подарков и углей")]
    public Outline Bag;
    public Outline MountainOfCoal;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (presentInhand != null)
            {
                Destroy(presentInhand);
                presentInhand = null;
                hotKeyBoard_Q.SetActive(false);
            }
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
        if (Input.GetMouseButtonDown(0))
        {
            if (presentInhand != null && canTrow)
            {
                Rigidbody rig = presentInhand.GetComponent<Rigidbody>();
                rig.AddRelativeForce(new Vector3(0, 0.05f, 1) * force, ForceMode.Impulse);
                rig.useGravity = true;
                presentInhand.transform.SetParent(playerTransform.parent.parent);
                presentInhand = null;
                hotKeyBoard_Q.SetActive(false);
            }
        }
    }
    private void CameraRotate()
    {
        if (GameController.canMove)
        {
            playerTransform.localRotation = Quaternion.Euler(0, -rotationX, 0);
            myTransform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        }
    }
    static public GameObject presentInhand;
    static public bool canTrow = true;
    private void RayPickUp()
    {

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.transform.gameObject.tag == "Bag" && presentInhand == null)
            {
                Bag.enabled = true;
                hotKeyBoard_E.SetActive(true);
            }
            else if(hit.transform.gameObject.tag == "MountainOfCoal" && presentInhand == null)
            {
                MountainOfCoal.enabled = true;
                hotKeyBoard_E.SetActive(true);
            }
            else
            {
                Bag.enabled = false;
                MountainOfCoal.enabled = false;
                hotKeyBoard_E.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && presentInhand == null)
            {
                if (hit.transform.gameObject.tag == "Bag")
                {
                    GameObject a = Instantiate<GameObject>(presents[Random.Range(0, presents.Count)]);
                    a.transform.SetParent(presentsPos);
                    a.transform.localPosition = Vector3.zero;
                    a.transform.localRotation = Quaternion.identity;
                    presentInhand = a;
                    hotKeyBoard_Q.SetActive(true);
                }
                else if(hit.transform.gameObject.tag == "MountainOfCoal")
                {
                    GameObject a = Instantiate<GameObject>(coals[Random.Range(0, coals.Count)]);
                    a.transform.SetParent(presentsPos);
                    a.transform.localPosition = Vector3.zero;
                    a.transform.localRotation = Quaternion.identity;
                    presentInhand = a;
                    hotKeyBoard_Q.SetActive(true);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
        
    }
}

