using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public int answerNumber;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //Check if it's the bullet
        if(other.gameObject.tag == "Bullet")
        {
            gameManager.AnswerCheck(answerNumber, GetComponent<Renderer>());
        }
    }
}
