using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour, IPointerClickHandler
{

    private LineRenderer lr;
    private Vector2 mousePos;
    private Vector2 startMousePos;
    private bool aux = true;

    [SerializeField] private Text distanceText;

    private float distance;

    
    /// <summary>
    /// Define-se os lineRenderer
    /// </summary>
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

/// <summary>
/// Responsável por criar os LineRenderers, utilizando-se da função wallDraweEnd após seu uso
/// </summary>
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

/// <summary>
/// desativa a funcionalidade do script
/// </summary>
    private void wallDrawerEnd()
    {
        this.GetComponent<LineDrawer>().enabled = false;
    }

/// <summary>
/// Ao se clicar duas vezes em uma lineDrawer especifica, o mesmo será deletado ((Ainda em desenvolvimento))
/// </summary>
/// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        // Deletar gameObject clicado duas vezes
        int i = eventData.clickCount;
        if(i == 2 && this.gameObject.CompareTag("Clone"))
            Destroy(this.gameObject);
    }

    /// <summary>
    /// Update para o wallDrawer se atualizar a cada quadro
    /// </summary>
    private void Update()
    {
        wallDrawer();
        
    }
    

}