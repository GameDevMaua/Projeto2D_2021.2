using UnityEngine;


public class DuplicateGameObject : MonoBehaviour
{
    public GameObject Square;

    /// <summary>
    ///Criação da classe duplicate, para clonar o game object
    /// 
    /// </summary>
    public void Duplicate()
    {
        GameObject duplicate = Instantiate(this.gameObject);// Clona o gameobject
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false); // Toda vez que clonar, clonar como filho de Canvas na hierarquia
        duplicate.transform.position = new Vector2(Square.transform.position.x, Square.transform.position.y); // Clonar na posicao do quadrado
        Component duplicatecommponent = duplicate.GetComponent<DuplicateGameObject>(); // atribuir em uma variavel o componente DuplicateGameObject
        Destroy(duplicatecommponent);  // Deletar esse componente
        duplicate.transform.tag = "Clone"; // Atribuir a tag Clone nos clones
    }
}