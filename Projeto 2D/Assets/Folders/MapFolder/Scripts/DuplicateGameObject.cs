using UnityEngine;


public class DuplicateGameObject : MonoBehaviour
{
    public GameObject Square;
    public GameObject RealObject;
    public GameObject elementalObject;
    public MapMovement mapMovement;
    private Vector3 aux;
    private float auxx;
    private float auxy;

    /// <summary>
    ///Criação da classe duplicate, para clonar o game object
    /// 
    /// </summary>
    public void Duplicate()
    {
        GameObject duplicate = Instantiate(this.gameObject);// Clona o gameobject
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false); // Toda vez que clonar, clonar como filho de Canvas na hierarquia
        duplicate.transform.position = new Vector2(Square.transform.position.x, Square.transform.position.y); // Clonar na posicao do quadrado
        aux = elementalObject.gameObject.transform.localScale.normalized;
        duplicate.transform.localScale = new Vector3((RealObject.transform.localScale.x)* (mapMovement.scalex+ 2.078f),
            (RealObject.transform.localScale.y)* mapMovement.scaley+ 2.078f);
        Component duplicatecommponent = duplicate.GetComponent<DuplicateGameObject>(); // atribuir em uma variavel o componente DuplicateGameObject
        Destroy(duplicatecommponent);  // Deletar esse componente
        duplicate.transform.tag = "Clone"; // Atribuir a tag Clone nos clones
    }
}