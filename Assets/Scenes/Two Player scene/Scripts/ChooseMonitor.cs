using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChooseMonitor : MonoBehaviour
{
     private void Awake()
    {
        if (GetComponent<PlayerInput>().playerIndex == 1)
        {
            Camera cam = GetComponentInChildren<Camera>();
            cam.targetDisplay = 1;
        }
    }
}

