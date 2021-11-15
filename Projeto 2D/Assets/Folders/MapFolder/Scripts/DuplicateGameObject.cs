using System;
using UnityEngine;
using UnityEngine.UI;


public class DuplicateGameObject : MonoBehaviour
{
    public GameObject square;
    public GameObject cloneRepository;
    public GameObject realObject;
    public MapMovement mapMovement;
    private float scalex;
    private float scaley;
    public bool deleteCountAux;

    /// <summary>
    ///Criação da classe duplicate, para clonar o game object
    /// 
    /// </summary>
    public void Duplicate()
    {
        GameObject duplicate = Instantiate(this.gameObject);// Clona o gameobject
        duplicate.transform.SetParent(cloneRepository.transform, false); // Toda vez que clonar, clonar como filho de Clones na hierarquia
        duplicate.transform.position = new Vector2(square.transform.position.x, square.transform.position.y); // Clonar na posicao do quadrado
        duplicate.transform.localScale = new Vector3((realObject.transform.localScale.x)* mapMovement.scalex+ 2.078f,
            (realObject.transform.localScale.y)* (mapMovement.scaley+ 2.078f));
        duplicate.GetComponent<Image>().preserveAspect = true;
        Component duplicatecommponent = duplicate.GetComponent<DuplicateGameObject>(); // atribuir em uma variavel o componente DuplicateGameObject
        Destroy(duplicatecommponent);  // Deletar esse componente
        duplicate.transform.tag = "Clone"; // Atribuir a tag Clone nos clones
    }


    public void DeletingLastChild()
    {
        int numChildren = cloneRepository.transform.childCount;
        if (numChildren >= 1)
        {
            Destroy(cloneRepository.transform.GetChild(numChildren - 1).gameObject);
            deleteCountAux = false;
        }
    }
}