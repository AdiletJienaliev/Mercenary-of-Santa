using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int HitAmount = 0;
    [Header("Сани")]
    public GameObject Sled;
    public float speedForUp;
    public float speedForMovefoward;
    [Header("Ограничения позиции")]
    public float MinY;
    public float MaxY;

    private Transform SledTransform;
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
        if (Input.GetKey(KeyCode.LeftShift) && SledTransform.position.y <= MaxY)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y + speedForUp * Time.deltaTime, SledTransform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftControl) && SledTransform.position.y >= MinY)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y - speedForUp * Time.deltaTime, SledTransform.position.z);
        }
    }
}
