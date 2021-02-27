using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public GameObject player;
    public GameObject sliderPlayer;    
    public float sliderBound;

    private Vector3 updatedPosition;
    private bool isSelected = false;


    void Update()
    {
        bool equal = GameManager.Instance.activePlayer.id == player.GetComponent<Player>().id;      



        if (Input.GetMouseButtonDown(0))
        {
            if (equal)
            {
                GameObject hit = GameManager.Instance.CheckByRay("Player" + player.GetComponent<Player>().id);
                if (hit != null)
                {
                    isSelected = true;
                }
            }
          
        }


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Input.GetMouseButtonDown(0))
        //{           
        //    if (Physics.Raycast(ray,out hit))
        //    {
        //        if (hit.collider.CompareTag("Slider"))
        //        {
        //            isSelected = true;
        //        }
        //    }
        //}

        if (Input.GetMouseButton(0) && isSelected)
        {
            Plane plane = new Plane(Vector3.up, 0);
            float enter = 0f;
            if (plane.Raycast(ray,out enter))
            {
                updatedPosition = new Vector3(Mathf.Clamp(ray.GetPoint(enter).x,-sliderBound,sliderBound),
                                                sliderPlayer.transform.position.y, 
                                                sliderPlayer.transform.position.z);
               
                sliderPlayer.transform.position = updatedPosition;
                player.transform.position = new Vector3(sliderPlayer.transform.position.x,
                                                        player.transform.position.y,
                                                        player.transform.position.z);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }
    }

    


}
