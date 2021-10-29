using UnityEngine;


public class Map : MonoBehaviour
{

    public KeyCode mapKey = KeyCode.Tab;
    private int countMapKey = 0;
    public Camera camera;
    public GameObject player;
    public GameObject map;
    public GameObject mapPlayerGameObject;
    private Transform mapTransform;
    private Transform playerTransform;
    public Canvas canvas;

    
    public void Start()
    {
        mapTransform = map.GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();
        camera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
        camera.transform.SetParent(playerTransform);
        map.transform.position = mapPlayerGameObject.transform.position;
        canvas.enabled = false;
    }

    private void mapKeyPressed()
    {
        countMapKey++;
    }
    void Update()
    {
        if (Input.GetKeyDown(mapKey) && countMapKey == 0)
        {

            mapKeyPressed();
            camera.transform.position = new Vector3(map.transform.position.x,map.transform.position.y,-10);
            camera.transform.SetParent(mapTransform);
            canvas.enabled = true;

        }
        else if (Input.GetKeyDown(mapKey) && countMapKey == 1)
        {
            countMapKey = 0;
            Debug.Log(countMapKey);
            camera.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
            camera.transform.SetParent(playerTransform);
            canvas.enabled = false;
   
        }
    }
}