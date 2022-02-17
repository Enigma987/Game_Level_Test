using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : EnemyManager
{
    public GameObject player;
    public GameObject lifeManager;

    EnemyManager enemyManager;

    public bool isStatic;
    public GameObject[] points;

    public List<GameObject> heartsObject;

    public GoblinScript(Enemy _enemy, GameObject _lifeManager, GameObject _player) : base(_enemy, _lifeManager, _player)
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        enemyManager = new EnemyManager(new Enemy(this.gameObject, points, heartsObject, GetComponent<Animator>(), GetComponent<Rigidbody2D>()), lifeManager, player);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStatic)
            enemyManager.Movement();

        if (hitPlayer)
        {
            enemyManager.HitThePlayer();
            hitPlayer = false;
        }
    }

    public void Hit()
    {
        enemyManager.GetHit();
    }

    private void FixedUpdate()
    {
        if (!isStatic)
            GetComponent<MovementController>().Move(enemyManager.HorizonatlMove * Time.fixedDeltaTime, false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            hitPlayer = true;
    }
}
