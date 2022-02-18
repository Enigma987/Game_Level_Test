using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject lifeManager;
    GameObject player;

    protected float horizontalMove;
    public float HorizonatlMove
    {
        get { return horizontalMove; }
    }

    protected bool walkRight = true;

    protected bool hitPlayer;

    Enemy enemy;
    public EnemyManager(Enemy _enemy, GameObject _lifeManager, GameObject _player)
    {
        enemy = _enemy;
        lifeManager = _lifeManager;
        player = _player;
    }

    public void Movement()
    {
        if (walkRight)
            horizontalMove = 10;
        else
            horizontalMove = -10;

        enemy.Animator.SetFloat("move", horizontalMove);


        if (Mathf.RoundToInt(enemy.Rigidbody2d.position.x) == Mathf.RoundToInt(enemy.Points[1].transform.position.x))
            walkRight = false;

        if (Mathf.RoundToInt(enemy.Rigidbody2d.position.x) == Mathf.RoundToInt(enemy.Points[0].transform.position.x))
            walkRight = true;
    }

    public void HitThePlayer()
    {
        player.GetComponent<Animator>().SetTrigger("getHit");
        if (player.gameObject.transform.position.x <= enemy.EnemyObject.transform.position.x)
            player.GetComponent<MovementController>().Move(-30, false, false);
        else
            player.GetComponent<MovementController>().Move(30, false, false);

        lifeManager.GetComponent<LifeManager>().LostHeart();
    }

    public void GetHit()
    {
        if (enemy.HeartsObject.Count > 1)
        {
            enemy.HeartsObject[enemy.HeartsObject.Count - 1].SetActive(false);
            enemy.HeartsObject.RemoveAt(enemy.HeartsObject.Count - 1);
        }
        else
        {
            enemy.Animator.SetTrigger("isDead");
            Destroy(enemy.EnemyObject.GetComponent<BoxCollider2D>());
            Destroy(enemy.EnemyObject.GetComponent<CircleCollider2D>());
        }
    }

    public virtual void SpecialAttack()
    {
        Debug.Log("It is a special attack");
    }
}
