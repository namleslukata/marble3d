using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isChangePlayer;

   
    public Player activePlayer;

    public Player player1;
    public Player player2;

    private PlayerController pc;
    
 

    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
        activePlayer.gameObject.SetActive(true);
        activePlayer.isActive = true;
        pc = GetComponent<PlayerController>();

    }

    public GameObject CheckByRay(string tag)
    {
        GameObject hitObject=null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
      
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag(tag))
                {
                hitObject= hit.collider.gameObject;
                
                }
            }
       return hitObject;
      }


    public void SetVelocityZero(Rigidbody rigid)
    {
        if (rigid.velocity.sqrMagnitude < .5f  )
        {
            rigid.velocity = Vector3.zero;
            isChangePlayer = true;           
                        
        }
            
    }
 
    public void SetActivePlayer()
    {
        if (activePlayer==player1)
        {
            activePlayer = player2;
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
           pc.pointB.transform.position = activePlayer.transform.position;

        }
        else 
        {
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
            activePlayer = player1;
        }
       


    }
  
   }

     
   

