using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public Transform playerPos;
    public Transform offScreenPos;
    public KeyCode mapKey = KeyCode.Tab;
    public float speed;
    private int countMapKey = 0;

    private void mapKeyPressed()
    {
        countMapKey++;
    }
    void Update()
    {
        if (Input.GetKeyDown(mapKey) && countMapKey == 0)
        {
            transform.position = playerPos.position;
            mapKeyPressed();
            Debug.Log(countMapKey);
        }
        else if (Input.GetKeyDown(mapKey) && countMapKey == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, offScreenPos.position, speed * Time.deltaTime);
            countMapKey = 0;
            Debug.Log(countMapKey);
        }
    }
}
