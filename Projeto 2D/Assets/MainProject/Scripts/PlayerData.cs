using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainProject.Scripts
{
    [Serializable]
    public class PlayerData
    {
        // Atributos que serão salvos
        public string savedScene;
        
        //public List<string> accessedScenes;

        /// <summary>
        /// Construtor de classe, utilizado para gerar um PlayerData a ser salvo
        /// </summary>
        public PlayerData(UnityEngine.SceneManagement.Scene actualScene)
        {
            savedScene = actualScene.name;
            //this.accessedScenes = accessedScenes;
        }
    }
}
