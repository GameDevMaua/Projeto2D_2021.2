using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiWallDrawer : MonoBehaviour, IPointerClickHandler
{
    public LineDrawer ld;

    public GameObject wallLine;
    public GameObject wallLineDrawer;
    public bool deleteCountAux = false;

    public void createWallLine()
    {
        GameObject duplicate = Instantiate(wallLineDrawer.gameObject);
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("WallLiner").transform, false);
        duplicate.GetComponent<LineDrawer>().enabled = true;
        duplicate.transform.tag = "Clone";
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        // Deletar ultimo filho criado
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            deleteCountAux = true;
            deletingLastChild();
        }
        
        // Deletar gameObject clicado duas vezes
        int i = eventData.clickCount;
        if(i == 2 && ld.gameObject.CompareTag("Clone"))
            Destroy(ld.gameObject);
    }

    public void deletingLastChild()
    {
        int numChildren = wallLine.transform.childCount; 
        Destroy(wallLine.transform.GetChild(numChildren-1).gameObject);
        deleteCountAux = false;
    }
    
    

}
