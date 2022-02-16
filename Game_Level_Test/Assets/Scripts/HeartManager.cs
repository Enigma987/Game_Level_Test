using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject lifeManager;

    Animator animator;

    public bool isCollect;

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
            lifeManager.GetComponent<LifeManager>().AddHeart();

            animator.SetTrigger("collect");
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
