using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiWallDrawer : MonoBehaviour
{
    public LineDrawer ld;
    
    public GameObject wallLine;

    public void createWallLine()
    {
        GameObject duplicate = Instantiate(wallLine.gameObject);
        duplicate.transform.SetParent(GameObject.FindGameObjectWithTag("WallLiner").transform, false);
        duplicate.GetComponent<LineDrawer>().enabled = true;
    }

}
