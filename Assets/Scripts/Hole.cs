using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private BallController ball;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBall")|| other.CompareTag("GreenBall"))
        {
            ball = other.gameObject.GetComponent<BallController>();
            GameManager.Instance.activePlayer.UpdateScore();
            Destroy(other.gameObject);

        }
     
    }
}
