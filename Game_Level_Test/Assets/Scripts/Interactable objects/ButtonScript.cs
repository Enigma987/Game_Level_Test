using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject brick;

    bool isOpen;

    bool canPush = false;

    private void Start()
    {
        isOpen = !brick.activeSelf;
    }
    // Update is called once per frame
    void Update()
    {
        if (canPush && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
                brick.SetActive(true);
            else
                brick.SetActive(false);

            isOpen = !brick.activeSelf;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            canPush = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPush = false;
    }
}
