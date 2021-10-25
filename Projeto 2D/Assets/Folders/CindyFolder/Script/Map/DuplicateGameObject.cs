using UnityEngine;

public class DuplicateGameObject : MonoBehaviour
{
    public GameObject Square;

    public void Duplicate()
    {
        GameObject duplicate = Instantiate(this.gameObject);
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        duplicate.transform.position = new Vector2(Square.transform.position.x, Square.transform.position.y);
        Component duplicatecommponent = duplicate.GetComponent<DuplicateGameObject>();
        Destroy(duplicatecommponent);
    }
}