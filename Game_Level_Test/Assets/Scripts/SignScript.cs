using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{
    public GameObject signCanvas;
    public Text text;
    public bool canShow;
    public string textToShow;

    // Update is called once per frame
    void Update()
    {
        if (canShow && Input.GetKeyDown(KeyCode.E))
        {
            signCanvas.SetActive(true);
            text.text = textToShow;
        }

        if(!canShow)
            signCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canShow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canShow = false;
    }
}
