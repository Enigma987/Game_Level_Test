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

    private bool hit;

    private string enemyType;

    public void EnemyHit()
    {
        if (hit)
        {
            switch (enemyType)
            {
                case "Mushroom":
                    Enemy.GetComponent<MushroomScript>().Hit();
                    break;
                case "Goblin":
                    Enemy.GetComponent<GoblinScript>().Hit();
                    break;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mushroom")
        {
            hit = true;
            enemy = collision.gameObject;
            enemyType = "Mushroom";
        }

        if (collision.tag == "Goblin")
        {
            hit = true;
            enemy = collision.gameObject;
            enemyType = "Goblin";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
        enemy = null;
    }
}
