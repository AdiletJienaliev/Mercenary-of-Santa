using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int HitAmount = 0;
    [Header("Сани")]
    public GameObject Sled;
    private Transform SledTransform;
    public float speedForUp;
    [Header("Позиции для конечной точки пути")]
    public Transform FihishWay;
    public float speedForMovefoward;
    private void Start()
    {
        SledTransform = Sled.GetComponent<Transform>();
    }
    private void Update()
    {
        InputKeyBoard();
        SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y, SledTransform.position.z + speedForMovefoward * Time.deltaTime);
    }
    private void InputKeyBoard()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y + speedForUp * Time.deltaTime, SledTransform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y - speedForUp * Time.deltaTime, SledTransform.position.z);
        }
    }
}
