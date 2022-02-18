using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject[] points;
    public GameObject[] edges;

    Rigidbody2D rigidbody;
    public bool walkRight = true;

    float horizontalMove;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (walkRight)
            horizontalMove = 10;
        else
            horizontalMove = -10;


        if (Mathf.RoundToInt(edges[1].transform.position.x) == Mathf.RoundToInt(points[1].transform.position.x))
            walkRight = false;

        if (Mathf.RoundToInt(edges[0].transform.position.x) == Mathf.RoundToInt(points[0].transform.position.x))
            walkRight = true;

    }
    private void FixedUpdate()
    {
        GetComponent<MovementController>().Move(horizontalMove * Time.fixedDeltaTime, false, true);
    }
}
