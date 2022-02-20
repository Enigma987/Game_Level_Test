using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemyObject;
    public GameObject EnemyObject
    {
        get { return enemyObject; }
        set { enemyObject = value; }
    }

    GameObject[] points;
    public GameObject[] Points
    {
        get { return points; }
        set { points = value; }
    }

    List<GameObject> heartsObject;
    public List<GameObject> HeartsObject
    {
        get { return heartsObject; }
        set { heartsObject = value; }
    }

    Animator animator;
    public Animator Animator
    {
        get { return animator; }
        set { animator = value; }
    }
    Rigidbody2D rigidbody2d;
    public Rigidbody2D Rigidbody2d
    {
        get { return rigidbody2d; }
        set { rigidbody2d = value; }
    }

    public Enemy(GameObject _enemyObject, GameObject[] _points, List<GameObject> _heartsObject, Animator _animator, Rigidbody2D _rigidbody2d)
    {
        enemyObject = _enemyObject;
        points = _points;
        heartsObject = _heartsObject;
        animator = _animator;
        rigidbody2d = _rigidbody2d;
    }
}
