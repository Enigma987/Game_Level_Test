using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberGoblinScript : EnemyManager
{
    public BomberGoblinScript(Enemy _enemy, GameObject _lifeManager, GameObject _player) : base(_enemy, _lifeManager, _player)
    {
    }

    public GameObject player;
    public GameObject lifeManager;
    public GameObject bomb;

    public EnemyManager enemyManager;


    public List<GameObject> heartsObject;

    private bool useSpecial;
    public bool UseSpecial
    {
        set { useSpecial = value; }
    }


    float fireRate;
    float nextFire;


    // Start is called before the first frame update
    void Start()
    {
        enemyManager = new EnemyManager(new Enemy(this.gameObject, null, heartsObject, GetComponent<Animator>(), GetComponent<Rigidbody2D>()), lifeManager, player);

        fireRate = 1f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPlayer)
        {
            enemyManager.HitThePlayer();
            SpecialAttack();
            hitPlayer = false;
        }

        if (Time.time > nextFire)
            useSpecial = true;

        if (useSpecial)
        {
            SpecialAttack();
            useSpecial = false;
        }
    }

    public void Hit()
    {
        enemyManager.GetHit();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            hitPlayer = true;
    }

    public override void SpecialAttack()
    {
        GetComponent<Animator>().SetTrigger("isAttack");

        Instantiate(bomb, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;

        UseSpecial = false;
    }
}
