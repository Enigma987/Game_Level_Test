using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject[] points;
    public GameObject[] edges;

    public bool walkRight = true;

    float horizontalMove;

    public bool isHorizontalMove;

    // Update is called once per frame
    void Update()
    {
        if (walkRight)
            horizontalMove = 10;
        else
            horizontalMove = -10;

        if (isHorizontalMove)
        {
            if (Mathf.RoundToInt(edges[1].transform.position.x) == Mathf.RoundToInt(points[1].transform.position.x))
                walkRight = false;

            if (Mathf.RoundToInt(edges[0].transform.position.x) == Mathf.RoundToInt(points[0].transform.position.x))
                walkRight = true;
        }
        else
        {
            if (Mathf.RoundToInt(edges[1].transform.position.y) == Mathf.RoundToInt(points[1].transform.position.y))
                walkRight = false;

            if (Mathf.RoundToInt(edges[0].transform.position.y) == Mathf.RoundToInt(points[0].transform.position.y))
                walkRight = true;
        }

    }
    private void FixedUpdate()
    {
        if(isHorizontalMove)
            GetComponent<MovementController>().PlatformMove(horizontalMove * Time.fixedDeltaTime, "right");

        if (!isHorizontalMove)
            GetComponent<MovementController>().PlatformMove(horizontalMove * Time.fixedDeltaTime, "up");
    }
}
