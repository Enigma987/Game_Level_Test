using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public CharacterController2d controller;

    public Animator animator;
    public Rigidbody2D rigidbody2d;

    public GameObject[] points;
    public float horizontalMove;

    public bool walkRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(points.Length > 0)
        {
            if (walkRight)
            {
                horizontalMove = 30;
                animator.SetFloat("move", horizontalMove);
            }
            else
            {
                horizontalMove = -30;
                animator.SetFloat("move", horizontalMove);
            }


            if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[1].transform.position.x))
                 walkRight = false;

            if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[0].transform.position.x))
                walkRight = true;

        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false);
    }
}
