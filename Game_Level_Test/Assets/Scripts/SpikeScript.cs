using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    bool activateTrap = false;
    public GameObject player;
    public LifeManager lifeManager;


    // Update is called once per frame
    void Update()
    {
        if (activateTrap)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);

            TrapHitThePlayer();
            Destroy(GetComponent<BoxCollider2D>());
            activateTrap = false;
        }
    }


    public void TrapHitThePlayer()
    {
        player.GetComponent<Animator>().SetTrigger("getHit");

        lifeManager.GetComponent<LifeManager>().LostHeart();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            activateTrap = true;

    }

}
