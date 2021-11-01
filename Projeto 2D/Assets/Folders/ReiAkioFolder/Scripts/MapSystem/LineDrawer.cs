using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{

    private LineRenderer lr;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    private bool aux = true;

    [SerializeField] private Text distanceText;

    private float distance;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }


    public void wallDrawer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (aux == true)
        {
            if (Input.GetMouseButton(0))
            {

                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                lr.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, -3f));
                lr.SetPosition(1, new Vector3(mousePos.x, mousePos.y, -3f));
                distance = (mousePos - startMousePos).magnitude;
                distanceText.text = distance.ToString("F2") + " meters";
                

            }
            if (Input.GetMouseButtonUp(0))
            {
                aux = false;
            }
        }
       
        

        if (aux == false)
        {
            wallDrawerEnd();
        }
       
    }

    private void wallDrawerEnd()
    {
        this.GetComponent<LineDrawer>().enabled = false;
    }

    private void Update()
    {
        wallDrawer();
        
    }
    

}