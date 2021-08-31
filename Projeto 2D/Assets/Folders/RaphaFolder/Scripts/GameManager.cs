using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Scene = UnityEditor.SearchService.Scene;

public class GameManager : MonoBehaviour
{
    [Header("Configurações do nível:")]
    public SceneAsset nextLevel; // O próximo nível pode ser definido pelo Inspector, mas deverá estar presente no build settings > Scenes in build
    
    // Atributos privados
    private UnityEngine.SceneManagement.Scene actualScene;

    private void Awake()
    {
        SaveGame();
        actualScene = SceneManager.GetActiveScene();
    }

    public void LoadNextLevel() => SceneManager.LoadScene(nextLevel.name);
    public void ReloadOnDeath() => SceneManager.LoadScene(actualScene.name);
    public void SaveGame() => Debug.Log("Game Saved");

    // Temporário para testes
    private void Update()
    {
        if ( GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().isPlayerDead() ) ReloadOnDeath();
    }
}
