using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Text[] numbersText = new Text[5];
    public int[] numbers = new int[5];

    public float timer;
    public float roundLength;

    public Text timeText;

    public TextMesh[] buttons;

    public float[] answers;

    public float result;

    public GameObject[] answerBox;

    public float score;
    public Text scoreText;

    public float level;
    public int[] maxScore = new int[5];
    public Text levelText;

    public PlayerCameraMovement PCMX, PCMY;

    public GameObject youWin;
    public Text winText;

    public GameObject youLost;
    public Text lostText;

    public GameObject inGameHud;

    // Start is called before the first frame update
    void Start()
    {
        //timer = roundLength;

        Cursor.visible = false;

        timer = 0.1f;
        SetScoreText();
        levelText.text = "Level: " + level.ToString();

        Time.timeScale = 1f;

        //PCM = GetComponent<PlayerCameraMovement>();

        //for(int i = 0; i < maxScore.Length; i++)
        //{
        //    maxScore[i] = (i + 100) * (i + 1);
        //}


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Time: " + timer.ToString();

        DisplayResults();

        //for(int i = 0; i < maxScore.Length; i++)
        //{
        //    if(score >= maxScore[i])
        //    {
        //        level = i + 1;
        //        levelText.text = "Level: " + level.ToString();
        //    }
        //}

        if (timer <= 0)
        {
            timer = roundLength;
            RandomNumbs();
            result = ((numbers[0] * numbers[1]) / numbers[2]) + numbers[3] - numbers[4];
            DisplayResults();

            answers[0] = result;
            answers[1] = result + Random.Range(1, 6);
            answers[2] = result + Random.Range(1, 6);
            ShuffleArray(answers);

            for (int i = 0; i < buttons.Length; i++)
            {
                //AnswerCheck(AB.answerNumber, GetComponent<Renderer>())material.color = Color.white;
                answerBox[i].GetComponent<Renderer>().material.color = Color.white;
            }

            //Another way to do them is bellow

            //foreach(GameObject obj in answerBox)
            //{
            //    obj.GetComponent<Renderer>().material.color = Color.white;
            //}

        //if(youWin)
        //    {
        //        Time.timeScale = 0f;
        //    }
        }
    }

    void RandomNumbs()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0, 10);
            numbersText[i].text = numbers[i].ToString();
        }
        if (numbers[2] == 0)
        {
            numbers[2] = Random.Range(1, 10);
            numbersText[2].text = numbers[2].ToString();
            Debug.Log("Re-did number");
        }
    }

    void DisplayResults()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.GetComponent<TextMesh>().text = answers[i].ToString();
        }
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    public void AnswerCheck(int ansNum, Renderer rend)
    {
        if (buttons[ansNum].gameObject.GetComponent<TextMesh>().text == result.ToString())
        {
            Debug.Log("Correct");
            rend.material.color = Color.green;
            score += 2 * timer;
            SetScoreText();
            level += 1;
            levelText.text = "Level: " + level.ToString();
        }
        else
        {

            Debug.Log("Wrong");
            Time.timeScale = 0f;
            rend.material.color = Color.red;
            score -= 15;
            SetScoreText();
            PCMY.canMove = false;
            PCMX.canMove = false;
            youLost.SetActive(true);
            inGameHud.SetActive(false);
            Cursor.visible = true;
        }

        timer = 0.1f;

        if(score >= 0)
        {
            scoreText.color = Color.green;
        }
        else
        {
            scoreText.color = Color.black;
        }

        if(level > 5)
        {
            Debug.Log("You Win!");
            Time.timeScale = 0f;
            PCMY.canMove = false;
            PCMX.canMove = false;
            youWin.SetActive(true);
            inGameHud.SetActive(false);
            Cursor.visible = true;
        }
        else
        {
            youWin.SetActive(false);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString("0");
        winText.text = "Your Final Score: " + score.ToString("0");
        lostText.text = "Your Final Score: " + score.ToString("0");
    }
}