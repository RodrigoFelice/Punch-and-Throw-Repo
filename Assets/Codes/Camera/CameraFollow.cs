using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Main Player")]
    [SerializeField] Transform player;

    [Header("Follow Point to Look")]
    [SerializeField] Transform followPoint;    
    
    void Update() => followPoint.transform.position = player.position;
}
