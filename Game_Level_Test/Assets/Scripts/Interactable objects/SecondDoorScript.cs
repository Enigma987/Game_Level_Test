using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoorScript : MonoBehaviour
{
    Animator doorAnimator;
    public GameObject redTrigger;
    public GameObject greenTrigger;

    public bool isRedActive = false;
    public bool IsRedActive
    {
        set { isRedActive = value; }
    }

    public bool isGreenActive = false;
    public bool IsGreenActive
    {
        set { isGreenActive = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRedActive && isGreenActive)
        {
            doorAnimator.SetTrigger("isOpen");
            Destroy(GetComponent<BoxCollider2D>());
        }    
    }
}
