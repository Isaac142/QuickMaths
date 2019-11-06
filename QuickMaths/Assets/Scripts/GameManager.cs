using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Text[] numbersText = new Text[2];
    public int[] numbers = new int[2];

    public float timer;
    public float roundLength;

    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timer = roundLength;


    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeText.text = "Time: " + timer.ToString();

        if(timer <= 0)
        {
            timer = roundLength;
            RandomNumbs();
        }
    }

    void RandomNumbs()
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Random.Range(0, 10);
            numbersText[i].text = numbers[i].ToString();
        }
    }
}
