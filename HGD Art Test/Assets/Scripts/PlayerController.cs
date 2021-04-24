using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/SebLague/Spherical-Gravity

public class PlayerController : MonoBehaviour
{
    // public vars
    public float walkSpeed = 6;

    // system vars
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    Rigidbody rigidbody;
    Animator anim;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        doMovement();


    }

    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
    }

    void doMovement()
    {
        // Calculates movement:
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        //set animator values for animation
        anim.SetFloat("horizontal", inputX);
        anim.SetFloat("vertical", inputY);
        anim.SetFloat("magnitude", moveDir.magnitude);

        if (inputX > 0) //Checks if player is facing either left or right, if not, set x scale to opposite depending on input
        {
            if (transform.GetChild(0).localScale.x < 0) //GetChild(0) 'HuskyNew' must be first gameObject below 'Player'
            {
                float rightScale = transform.GetChild(0).localScale.x * -1;
                transform.GetChild(0).localScale = new Vector3(rightScale, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            }
        }
        if (inputX < 0)
        {
            if (transform.GetChild(0).localScale.x > 0)
            {
                float leftScale = transform.GetChild(0).localScale.x * -1;
                transform.GetChild(0).localScale = new Vector3(leftScale, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            }
        }
    }

}
