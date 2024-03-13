using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Sprite[] cards;
    public Image player;
    public Image enemy;

    public float limitTime = 5.0f;

    public TMP_Text timer;
    public TMP_Text score;

    public bool isReady = false;

    public int enemyNum;
    public int playerNum;

    public int playerScore;
    public int enemyScore;

    enum CardType //열거형 타입
    {
        Rock,
        Scissors,
        Paper
    }

    CardType cardType;

    // Start is called before the first frame update
    void Start()
    {
        RoundStart();
    }

    // Update is called once per frame
    void Update()
    {
        //limitTime -= Time.deltaTime;
        if (limitTime > 0)
        {
            limitTime -= Time.deltaTime;
            timer.text = "Time : " + Mathf.Round(limitTime);

            isReady = true;
        }
        else 
        {
            isReady = false;
            enemy.GetComponent<Image>().sprite = cards[enemyNum];


        }
    }

    public void RoundStart()
    {
        enemyNum = Random.Range(0, 3);
    }

    public void RoundSet()
    {

    }

    public void PlayerSelect(int cardNum)
    {
        playerNum = cardNum;

        if (isReady == true)
        {
            Debug.Log(cardNum);
            player.GetComponent<Image>().sprite = cards[cardNum];
        }

        return;
    }
}
