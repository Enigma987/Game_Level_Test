using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    public GameObject endGameCanvas;

    public GameObject player;

    public Text playerCoinText;
    public Text endCoinText;

    public Text playerHeartText;
    public Text endHeartText;

    public Text finalPointsText;

    int coinsPoints;
    int heartsPoints;
    int finalPoints;

    public void Display()
    {
        player.GetComponent<CharacterManager>().CanMove = false;

        endGameCanvas.SetActive(true);

        playerCoinText.text = player.GetComponent<CharacterManager>().Coins.ToString();
        coinsPoints = player.GetComponent<CharacterManager>().Coins * 1;
        endCoinText.text = coinsPoints.ToString();

        playerHeartText.text = player.GetComponent<CharacterManager>().Hearts.ToString();
        heartsPoints = player.GetComponent<CharacterManager>().Hearts * 5;
        endHeartText.text = heartsPoints.ToString();

        finalPoints = coinsPoints + heartsPoints;
        finalPointsText.text = finalPoints.ToString();
    }
}
