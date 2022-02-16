using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    public GameObject lifeManager;
    public CharacterController2d controller;
    public GameObject player;

    public Animator animator;
    public Rigidbody2D rigidbody2d;

    public GameObject[] points;
    public float horizontalMove;

    public bool walkRight;

    public bool hitPlayer;

    public int heartsNumber;
    public List<GameObject> hearstObject;

    CircleCollider2D playerCircleCollider;

    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        playerCircleCollider = player.GetComponent<CircleCollider2D>();
        heartsNumber = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            horizontalMove = 0;
            animator.SetFloat("move", horizontalMove);
        }
        else
        {
            if (points.Length > 0)
            {
                if (walkRight)
                {
                    horizontalMove = 10;
                    animator.SetFloat("move", horizontalMove);
                }
                else
                {
                    horizontalMove = -10;
                    animator.SetFloat("move", horizontalMove);
                }


                if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[1].transform.position.x))
                    walkRight = false;

                if (Mathf.RoundToInt(rigidbody2d.position.x) == Mathf.RoundToInt(points[0].transform.position.x))
                    walkRight = true;

            }

            if (hitPlayer)
            {
                hitPlayer = false;

                if (player.gameObject.transform.position.x <= transform.position.x)
                    lifeManager.GetComponent<LifeManager>().LostHeart(-30f);
                else
                    lifeManager.GetComponent<LifeManager>().LostHeart(30f);
            }
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            hitPlayer = true;
    }

    public void Hit()
    {
        if (heartsNumber > 0)
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
