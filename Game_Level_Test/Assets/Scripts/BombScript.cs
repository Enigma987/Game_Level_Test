using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rigidbody;

    GameObject target;
    GameObject motherObject;

    Vector2 moveDirection;

    bool hitToGround;
    bool hitToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player");
        motherObject = GameObject.FindGameObjectWithTag("Bomber Goblin");

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (hitToGround)
        {
            Destroy(gameObject);
        }

        if (hitToPlayer)
        {
            motherObject.GetComponent<BomberGoblinScript>().enemyManager.HitThePlayer();
            hitToPlayer = false;
            Destroy(gameObject);
        }
    }

    public bool HitPlayer()
    {
        return hitToPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            hitToGround = true;

        if (collision.tag == "Player")
            hitToPlayer = true;
    }
}
