using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Move Attributes")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Physics")]
    Rigidbody rb;
    Vector3 movement, direction;
    Quaternion newRotation;

    [Header("Outside References")]
    Inputs inputs;
    Animations animationsController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        inputs = GetComponent<Inputs>();
        animationsController = GetComponent<Animations>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(inputs.horizontal, 0f, inputs.vertical) * moveSpeed * Time.fixedDeltaTime;

        Move_Player();
        Rotation_Player();
    }

    void Move_Player()
    {
        direction = transform.forward * movement.magnitude;
        animationsController.MoveAnimation(movement);
        rb.MovePosition(rb.position + direction);
    }

    void Rotation_Player()
    {
        if (movement != Vector3.zero)
        {
            newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);
        }
    }
}
