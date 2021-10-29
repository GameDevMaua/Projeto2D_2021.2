using UnityEngine;

public class MapMovement : MonoBehaviour
{
    public RectTransform bound;
    public RectTransform map;
    private float scalex;
    private float scaley;
    public GameObject playerGameObject;
    public float positionx = 0;
    public float positiony = 0;


    private void Awake()
    {
        scalex = map.sizeDelta.x*map.localScale.x / bound.sizeDelta.x*map.localScale.y;
        scaley = map.sizeDelta.y / bound.sizeDelta.y;
        this.gameObject.transform.position = new Vector3(playerGameObject.transform.position.x * scalex + positionx,
            playerGameObject.transform.position.y * scaley+ positiony);

    }
    
    void Update()
    {
        this.gameObject.transform.position = new Vector3(playerGameObject.transform.position.x * scalex + positionx,
            playerGameObject.transform.position.y * scaley + positiony);

    }


}
