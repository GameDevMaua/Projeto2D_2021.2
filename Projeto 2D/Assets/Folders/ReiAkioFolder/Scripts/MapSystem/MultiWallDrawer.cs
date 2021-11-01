using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiWallDrawer : MonoBehaviour, IPointerClickHandler
{
    public LineDrawer ld;
    
    public GameObject wallLine;
    public bool deleteCountAux = false;

    public void createWallLine()
    {
        GameObject duplicate = Instantiate(wallLine.gameObject);
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("WallLiner").transform, false);
        duplicate.GetComponent<LineDrawer>().enabled = true;
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            deleteCountAux = true;
            
        }
    }

}
