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

    /// <summary>
    /// Ao se clicar com o botão esquerdo no iconde do wallDrawerCreator, irá ativar se criar um clone funcional de um lineDrawer
    /// </summary>
    public void createWallLine()
    {
        GameObject duplicate = Instantiate(wallLineDrawer.gameObject);
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("WallLiner").transform, false);
        duplicate.GetComponent<LineDrawer>().enabled = true;
        duplicate.transform.tag = "Clone";
        
    }
    
    /// <summary>
    /// Ao se clicar com o botão direito no icone do wallDrawerCreator irá ativar a função deletingLastChild
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        
        // Deletar ultimo filho criado
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            deleteCountAux = true;
            deletingLastChild();
        }
        
    }
/// <summary>
/// identifica quantos filhos possuem o GameObject pai dos lineDrawers e deleta o ultimo criado caso haja pelo menos um
/// </summary>
    public void deletingLastChild()
    {
        int numChildren = wallLine.transform.childCount;
        if (numChildren > 1)
        {
            Destroy(wallLine.transform.GetChild(numChildren - 1).gameObject);
            deleteCountAux = false;
        }
    }
    
    

}
