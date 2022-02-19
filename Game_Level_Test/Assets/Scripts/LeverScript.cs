using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject door;
    Animator doorAnimator;
    Animator leverAnimator;

    bool open;

    // Start is called before the first frame update
    void Start()
    {
        leverAnimator = GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(open && Input.GetKeyDown(KeyCode.E))
        {
            leverAnimator.SetTrigger("open");
            Destroy(GetComponent<BoxCollider2D>());

            doorAnimator.SetTrigger("isOpen");
            Destroy(door.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            open = true;
        }
    }
}
