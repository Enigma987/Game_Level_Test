using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public GameObject lifeManager;
    public GameObject player;

    MovementController controller;
    Animator animator;
    Rigidbody2D rigidbody2d;

    public bool isStatic;
    public GameObject[] points;

    private float horizontalMove;
    private bool walkRight;
    private bool hitPlayer;

    private int heartsNumber = 2;
    public List<GameObject> hearstObject;

    // Start is called before the first frame update
    void Start()
    {
        if(!isStatic)
            controller = GetComponent<MovementController>();

        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStatic)
        {
            if (walkRight)
                horizontalMove = 10;
            else
                horizontalMove = -10;

            animator.SetFloat("move", horizontalMove);


            if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[1].transform.position.x))
                walkRight = false;

            if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[0].transform.position.x))
                walkRight = true;
        }

        if (hitPlayer)
        {
            hitPlayer = false;

            player.GetComponent<Animator>().SetTrigger("getHit");
            if (player.gameObject.transform.position.x <= transform.position.x)
                player.GetComponent<MovementController>().Move(-30, false);
            else
                player.GetComponent<MovementController>().Move(30, false);

            lifeManager.GetComponent<LifeManager>().LostHeart();
        }
    }
    private void FixedUpdate()
    {
        if(!isStatic)
            controller.Move(horizontalMove * Time.fixedDeltaTime, false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            hitPlayer = true;
    }

    public void GetHit()
    {
        if (heartsNumber > 1)
        {
            heartsNumber--;
            hearstObject[hearstObject.Count - 1].SetActive(false);
            hearstObject.RemoveAt(hearstObject.Count - 1);
        }
        else
        {
            animator.SetTrigger("isDead");
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<CircleCollider2D>());
        }    
    }
}
