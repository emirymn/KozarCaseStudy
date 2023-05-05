using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    [SerializeField] Transform playerCameraPos;
     void Update()
    {
        transform.position = playerCameraPos.position;
    }
}
