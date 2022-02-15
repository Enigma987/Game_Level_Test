using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2d controller;
    public Animator animator2d;
    public Rigidbody2D rigidbody2d;

    public float horizonatlMove = 0f;

    public float moveSpeed;

    public bool jump;

    // Start is called before the first frame update
    void Start()
    {
        animator2d = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizonatlMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        animator2d.SetFloat("moveX", horizonatlMove);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizonatlMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
