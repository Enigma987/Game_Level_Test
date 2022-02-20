using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonesScript : MonoBehaviour
{
    public string colorTrigger;
    public GameObject secondDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Red Block" && colorTrigger == "red")
            secondDoor.GetComponent<SecondDoorScript>().IsRedActive = true;

        if (collision.tag == "Green Block" && colorTrigger == "green")
            secondDoor.GetComponent<SecondDoorScript>().IsGreenActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Red Block" && colorTrigger == "red")
            secondDoor.GetComponent<SecondDoorScript>().IsRedActive = false;

        if (collision.tag == "Green Block" && colorTrigger == "green")
            secondDoor.GetComponent<SecondDoorScript>().IsGreenActive = false;
    }
}
