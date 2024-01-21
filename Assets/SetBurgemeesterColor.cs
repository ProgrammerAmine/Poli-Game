using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBurgemeesterColor : MonoBehaviour
{

void Start()
    {
        foreach(Transform child in transform.GetComponentsInChildren<Transform>())
            {
                if(!child.TryGetComponent<Renderer>(out Renderer rend)) continue;
                    rend.material.SetColor("_MainColor", Color.blue);
                    rend.material.SetFloat("_xDitherStretch", 0);
                    rend.material.SetFloat("_yDitherStretch", 0);
            }
    }
}
