using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainProject.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private MainProject.Scripts.Player.PlayerStatus playerStatus;
        private MainProject.Scripts.Player.PlayerSoundManager playerSoundManager;
        
        [Header("Configurações do nível:")]
        public SceneAsset nextLevel; // O próximo nível pode ser definido pelo Inspector, mas deverá estar presente no build settings > Scenes in build

        // Atributos privados
        private UnityEngine.SceneManagement.Scene actualScene;

        public Animator animator;

        // Inicializa valores padrões e executa métodos básicos
        private void Awake()
        {
            SaveGame();
            actualScene = SceneManager.GetActiveScene();
            playerStatus = GameObject.FindWithTag("Player").GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            playerSoundManager =  GameObject.FindWithTag("Player").GetComponent<MainProject.Scripts.Player.PlayerSoundManager>();
        }

        /// <summary>
        /// Carrega a próxima fase
        /// </summary>
        public void LoadNextLevel()
        {
            StartCoroutine(transition(3));
        }

        /// <summary>
        /// Recarrega a fase atual
        /// </summary>
        public void ReloadOnDeath() => StartCoroutine(transition2(2));

        /// <summary>
        /// Salva o jogo
        /// </summary>
        public void SaveGame()
        {
            var data = new MainProject.Scripts.PlayerData(actualScene);
            MainProject.Scripts.SaveSystem.SaveGame(data);
        }

        // Temporário para testes
        private void Update()
        {
            if (playerStatus.isPlayerDead())
            {
                playerSoundManager.deathSoundReload();
                ReloadOnDeath();
            }
        }

        private IEnumerator transition(float delayTime)
        {
            playerSoundManager.nextLevelSound();
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(nextLevel.name);
        }
        
        private IEnumerator transition2(float delayTime)
        {
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(actualScene.name);
        }
    }
}
