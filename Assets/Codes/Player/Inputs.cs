using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] FixedJoystick joystick;

    [Header("Movement")]
    [HideInInspector] public float vertical,horizontal;  

    [Header("Punch Inputs")]
    Animations animationsControllerReference;
    [SerializeField] KeyCode punchInput;

    [Header("Throw Inputs")]
    [SerializeField] ContainerOfEnemies containerOfEnemiesReference;
    [SerializeField] KeyCode throwInput;


    void Start() => animationsControllerReference = GetComponent<Animations>();

    void Update()
    {
       horizontal = joystick.Horizontal;
       vertical = joystick.Vertical;

       if(Input.GetKeyDown(punchInput)) animationsControllerReference.CalledPunch();
        
       if(Input.GetKeyDown(throwInput)) containerOfEnemiesReference.ThrowEnemie(); 
    }
}
