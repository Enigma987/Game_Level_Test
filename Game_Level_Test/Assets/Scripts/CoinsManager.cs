using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public GameObject player;
    public Text numberOfCoin;

    Animator animator;
    private bool isCollect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollect)
        {
            player.GetComponent<CharacterManager>().Coins++;
            numberOfCoin.text = player.GetComponent<CharacterManager>().Coins.ToString();

            animator.SetTrigger("isCollect");
            Destroy(GetComponent<BoxCollider2D>());
            isCollect = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isCollect = true;
    }
}
