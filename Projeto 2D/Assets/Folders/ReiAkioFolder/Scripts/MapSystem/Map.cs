using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public Transform playerPos;
    public Transform offScreenPos;
    public KeyCode mapKey = KeyCode.Tab;
    public float speed;
    private int countMapKey = 0;
    public GameObject mp ;
    public GameObject ms ;
    public Canvas canvas;

    public void Start()
    {
        mp.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ms.gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
            mp.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            ms.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            canvas.enabled = true;
            mapKeyPressed();
            Debug.Log(countMapKey);
            
        }
        else if (Input.GetKeyDown(mapKey) && countMapKey == 1)
        {
            countMapKey = 0;
            Debug.Log(countMapKey);
            mp.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ms.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            canvas.enabled = false;
        }
    }
}
