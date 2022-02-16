using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    GameObject enemy;
    public GameObject Enemy
    {
        get { return enemy; }
        set { enemy = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GetComponentInParent<CharacterManager>().EnemyHit = true;
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<CharacterManager>().EnemyHit = false;
        enemy = null;
    }
}
