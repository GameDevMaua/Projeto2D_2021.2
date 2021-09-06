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

    // Inicializa valores padrões e executa métodos básicos
    private void Awake()
    {
        SaveGame();
        actualScene = SceneManager.GetActiveScene();
    }

    /// <summary>
    /// Carrega a próxima fase
    /// </summary>
    public void LoadNextLevel() => SceneManager.LoadScene(nextLevel.name);
    /// <summary>
    /// Recarrega a fase atual
    /// </summary>
    public void ReloadOnDeath() => SceneManager.LoadScene(actualScene.name);

    /// <summary>
    /// Salva o jogo
    /// </summary>
    public void SaveGame()
    {
        PlayerData data = new PlayerData(actualScene);
        SaveSystem.SaveGame(data);
    }

    // Temporário para testes
    private void Update()
    {
        if ( GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().isPlayerDead() ) ReloadOnDeath();
    }
}
