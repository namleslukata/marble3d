using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{

   
    private Vector3 tempPos;
   

    // Update is called once per frame
    void Update()
    {
        
            tempPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));            
            transform.position = new Vector3(tempPos.x, .6f,tempPos.z);
       


    }
}
