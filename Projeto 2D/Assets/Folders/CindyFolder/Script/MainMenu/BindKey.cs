using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BindKey : MonoBehaviour
{
    public ChangeKeyBind changeKeyBind;
    public KeyCode [] key;
    public MainProject.Scripts.Player.PlayerMovement prefabPlayerMovement;
    public GameObject prefab;
    private int i = 0;

    public void LeftButton()
    {
        i = 0;
        key = new KeyCode[2];
    }
    // Update is called once per frame
    private void Update( )
    {
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKeyDown(vKey))
            {
                key[i] = vKey;
                Debug.Log(key[i]);
                Debug.Log(i);
                prefabPlayerMovement.ChangeLeftKey(key[i]);
                i++;
                PrefabUtility.RecordPrefabInstancePropertyModifications(prefab);
                if (i >= 1)
                {
                    changeKeyBind.changeButtonImage.SetActive(false);
                }
            }
            
        }
    }
}


