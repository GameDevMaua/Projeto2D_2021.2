using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeletingMapObject : MonoBehaviour
{

    public GameObject clickedMapGameObject;

    public void assignClickedObject()
    {
        
    }
    
    public void deletingGameObjectOnClick()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(clickedMapGameObject);
            Debug.Log("deletei o mapGameObject");
        }
    }
}
