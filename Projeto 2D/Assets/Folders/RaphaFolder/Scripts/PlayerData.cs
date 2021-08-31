using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    // Atributos que serão salvos
    public string currentScene;
    public List<string> accessedScenes;

    /// <summary>
    /// Construtor de classe, utilizado para gerar um PlayerData a ser salvo
    /// </summary>
    public PlayerData(UnityEngine.SceneManagement.Scene actualScene, List<string> accessedScenes)
    {
        currentScene = actualScene.name;
        this.accessedScenes = accessedScenes;
    }
}
