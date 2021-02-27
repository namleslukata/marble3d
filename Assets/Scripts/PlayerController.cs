using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    
    private Player activePlayer;
    private Rigidbody rb;
    private LineRenderer line;
   


    //*******Drag & Shoot Settingss**************//
    public GameObject pointA;
    public GameObject pointB;
    //public GameObject arrow;
    //public GameObject circle;

    //private float offset = -1.1f;
    //private bool isShoot;
    private float currentDistance;
    public float maxDistance = 3f;
    private float safeArea;
    public float shootPower=25f;
    private Vector3 shootDirection;
    private bool isReady;
    



    
    void Start()
    {
        activePlayer = GameManager.Instance.activePlayer;
        rb = activePlayer.GetComponent<Rigidbody>();
        line = activePlayer.GetComponent<LineRenderer>();

        // pointB.transform.position = new Vector3(pointA.transform.position.x, pointA.transform.position.y, offset);
        pointB.transform.position = activePlayer.transform.position;
        
    }

   private void Update()
    {
        activePlayer = GameManager.Instance.activePlayer;
        line = activePlayer.GetComponent<LineRenderer>();
        if (Input.GetMouseButton(0))
        {
            if (GameManager.Instance.CheckByRay("Player")!=null)
            {
                isReady = true;
            }

            if (isReady)
            {           

            currentDistance = Vector3.Distance(pointA.transform.position, activePlayer.transform.position);
           
            if (currentDistance <= maxDistance)
            {
                safeArea = currentDistance;
            }
            else
            {
                safeArea = maxDistance;
            }

            shootPower =Mathf.Clamp( Mathf.Abs(safeArea) * 20,0,10);

            Vector3 dixy = pointA.transform.position - activePlayer.transform.position;
            float difference = dixy.magnitude;

               
            pointB.transform.position = activePlayer.transform.position + ((dixy / difference) * currentDistance * -1);
            //pointB.transform.position = new Vector3(pointB.transform.position.x,
            //                                        .6f, pointB.transform.position.z);
              shootDirection = Vector3.Normalize(pointA.transform.position - activePlayer.transform.position);
            DrawLine();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isReady)
            {
                ResetLine();
                rb.AddForce(shootDirection * shootPower * -1, ForceMode.Impulse);
                isReady = false;
                                                                       
            }
         
        }
      

        GameManager.Instance.SetVelocityZero(rb);
    }
  


  

    private void SetArrowAndCircle()
    {
        //arrow.gameObject.SetActive(true);
        //circle.gameObject.SetActive(true);

        //if (currentDistance <= maxDistance)
        //{
        //    arrow.transform.position = new Vector3((2 * transform.position.x) - pointA.transform.position.x,
        //                                            0.6f, (2 * transform.position.z) - pointA.transform.position.z);
        //}
        //else
        //{
        //    Vector3 dixy = pointA.transform.position - transform.position;
        //    float difference = dixy.magnitude;

        //    arrow.transform.position = transform.position + ((dixy / difference) * maxDistance * -1);
        //    arrow.transform.position = new Vector3(arrow.transform.position.x,
        //                                            .6f, arrow.transform.position.z);

        //}

        //circle.transform.position = transform.position + new Vector3(-0.02f, 0.04f, 0.01f);
        //Vector3 dir = pointA.transform.position - transform.position;
        //float rot;
        //if (Vector3.Angle(dir,transform.forward)>90)
        //{
        //    rot = Vector3.Angle(dir, transform.right);
        //}
        //else
        //{
        //    rot = Vector3.Angle(dir, transform.right)*-1;
        //}
        //arrow.transform.eulerAngles = new Vector3(90, rot, -90);

        //float scaleX = Mathf.Log(1 + safeArea / 2, 2) * 2.4f;
        //float scaleY = Mathf.Log(1 + safeArea / 2, 2) * 2.4f;

        //arrow.transform.localScale = new Vector3(.5f + scaleX, .5f + scaleY, 0.001f);
        //circle.transform.localScale = new Vector3(.5f + scaleX, .5f + scaleY, 0.001f);
    }

    private void DrawLine()
    {
        ResetLine();
       line.positionCount = 2;
        line.startWidth = 0.07f;
        line.endWidth = 0.01f;
       var start = activePlayer.transform.position;
        var  end = pointB.transform.position;
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        
    }
    private void ResetLine()
    {
        line.positionCount = 0;
    }

   
   
}
