using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{
    public GameObject signCanvas;
    public Text text;
    private bool canShow;
    public string textToShow;

    public void ShowMessage()
    {
        signCanvas.SetActive(true);
        text.text = textToShow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            ShowMessage();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            signCanvas.SetActive(false);
    }
}
