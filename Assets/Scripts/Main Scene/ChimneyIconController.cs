using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyIconController : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = null;
        this.enabled = false;
    }
}
