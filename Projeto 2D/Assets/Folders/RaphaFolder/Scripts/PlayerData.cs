using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string currentScene;
    public List<string> accessedScenes;

    public PlayerData(UnityEngine.SceneManagement.Scene actualScene, List<string> accessedScenes)
    {
        currentScene = actualScene.name;
        this.accessedScenes = accessedScenes;
    }
}
