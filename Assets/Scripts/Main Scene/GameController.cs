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
    public static bool Mainpos = true;

    private Transform SledTransform;
    private void Start()
    {
        SledTransform = Sled.GetComponent<Transform>();
    }
    private void Update()
    {
        InputKeyBoard();
        if (HitAmount != 0)
        {
            SledTransform.position = new Vector3(SledTransform.position.x, SledTransform.position.y, SledTransform.position.z + speedForMovefoward * Time.deltaTime);
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
}
