using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            GetComponentInParent<GoblinScript>().UseSpecial = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponentInParent<GoblinScript>().UseSpecial = false;
    }
}
