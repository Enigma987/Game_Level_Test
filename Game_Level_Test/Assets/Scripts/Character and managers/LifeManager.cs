using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject endGameCanvas;

    CharacterManager characterManager;
    public List<Image> heartsImages;

    private int numberOfHearts;


    // Start is called before the first frame update
    void Start()
    {
        characterManager = player.GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfHearts = characterManager.Hearts;
        DisplayHearts();
    }

    public void DisplayHearts()
    {
        foreach (var element in heartsImages)
            element.gameObject.SetActive(false);

        for (int i = 0; i < numberOfHearts; i++)
            heartsImages[i].gameObject.SetActive(true); 
    }

    public void LostHeart()
    {
        if (characterManager.Hearts > 1)
            characterManager.Hearts--;
        else
        {
            endGameCanvas.SetActive(true);
            player.GetComponent<Animator>().SetTrigger("isDie");
            Destroy(player.GetComponent<CircleCollider2D>());
            characterManager.CanMove = false;
        }
    }

    public void AddHeart()
    {
        characterManager.Hearts++;
    }
}
