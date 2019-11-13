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

    public float answers;
    // Start is called before the first frame update
    void Start()
    {
        //timer = roundLength;

        timer = 0.1f;


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Time: " + timer.ToString();

        if (timer <= 0)
        {
            timer = roundLength;
            RandomNumbs();
            answers = ((numbers[0] * numbers[1]) / numbers[2]) + numbers[3] - numbers[4];
            DisplayResults();
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
            Debug.Log("Redid number");
        }
    }

    void DisplayResults()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.GetComponent<TextMesh>().text = answers.ToString();
        }
    }
}
