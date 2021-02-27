using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public BallController playerBall;
    public int id;
    public int score;

    //UI
    public GameObject img;
    public Text scoreText;
    public Transform start;
    public bool isActive;




    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
     public void Reset()
    {
        transform.position = start.position;
    }   
}
