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

    //public int enemyNum;
    public int playerNum;

    public int playerScore;
    public int enemyScore;

    enum CardType //열거형 타입
    {
        Rock = 0,
        Scissors = 1,
        Paper = 2
    }

    CardType cardType;

    // Start is called before the first frame update
    void Start()
    {
        score.text = playerScore + " : " + enemyScore;
        RoundSet();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady == true)
        {
            RoundStart();
        }
    }

    public void RoundSet()
    {
        limitTime = 5f;
        enemy.GetComponent<Image>().sprite = cards[3];
        //player.GetComponent<Image>().sprite = cards[3];
        timer.text = "Ready";
        Invoke("RoundReady", 1f);
    }
    public void RoundStart()
    {
        if (limitTime > 0)
        {
            limitTime -= Time.deltaTime;
            timer.text = "Time : " + Mathf.Round(limitTime);
        }
        else
        {
            RoundResult();
            isReady = false;
        }
    }

    public void RoundResult()
    {
        timer.text = "Reslut";
        int enemyNum = Random.Range(0, 3);
        enemy.GetComponent<Image>().sprite = cards[enemyNum];
        int result = playerNum - enemyNum;

        if(result == 0)
        {
            Debug.Log("Draw");
        }
        else if (result == -1 || result == 2)
        {
            playerScore += 1;
            Debug.Log("Win");
        }
        else
        {
            enemyScore += 1;
            Debug.Log("Lose");
        }

        score.text = playerScore + " : " + enemyScore;
        Invoke("RoundSet", 1f);
    }

    public void RoundReady()
    {
        isReady = true;
    }

    public void PlayerSelect(int cardNum)
    {
        playerNum = cardNum;

        if (isReady == true)
        {
            player.GetComponent<Image>().sprite = cards[cardNum];

            switch (playerNum)
            {
                case (int)CardType.Rock:
                    Debug.Log("바위");
                    break;
                case (int)CardType.Scissors:
                    Debug.Log("가위");
                    break;
                case (int)CardType.Paper:
                    Debug.Log("보");
                    break;
            }
        }

        return;
    }
}
