using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public GameObject player;
    
    public GameObject coin;
    Animator animator;
    public Text numberOfCoin;

    public bool isCollect;

    // Start is called before the first frame update
    void Start()
    {
        animator = coin.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollect)
        {
            player.GetComponent<CharacterManager>().UpgradeCoins();
            numberOfCoin.text = player.GetComponent<CharacterManager>().GetNumberOfCoins().ToString();

            animator.SetTrigger("isCollect");
            Destroy(coin.GetComponent<BoxCollider2D>());
            isCollect = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isCollect = true;
    }
}
