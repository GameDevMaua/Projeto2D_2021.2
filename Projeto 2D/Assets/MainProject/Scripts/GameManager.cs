using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif

namespace MainProject.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private MainProject.Scripts.Player.PlayerStatus playerStatus;
        [SerializeField] private MainProject.Scripts.Player.PlayerSoundManager playerSoundManager;
        private MainProject.Scripts.Player.PlayerMovement playerMovement;
        private bool hasPlayer;
        
        // #if UNITY_EDITOR
        // [Header("Configurações do nível:")]
        // public SceneAsset nextLevel; // O próximo nível pode ser definido pelo Inspector, mas deverá estar presente no build settings > Scenes in build
        // #endif
        [Header("Configurações do nível:")] public string nextLevel;

        // Atributos privados
        private UnityEngine.SceneManagement.Scene actualScene;

        public Animator animator;

        // Inicializa valores padrões e executa métodos básicos
        private void Awake()
        {
            actualScene = SceneManager.GetActiveScene();
            SaveGame();
            if (GameObject.FindWithTag("Player") == null)
            {
                hasPlayer = false;
                return;
            }

            hasPlayer = true;
            playerStatus = GameObject.FindWithTag("Player").GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            playerSoundManager = GameObject.FindWithTag("Player")
                .GetComponent<MainProject.Scripts.Player.PlayerSoundManager>();
            playerMovement = GameObject.FindWithTag("Player")
                .GetComponent<MainProject.Scripts.Player.PlayerMovement>();
        }

        /// <summary>
        /// Carrega a próxima fase
        /// </summary>
        public void LoadNextLevel()
        {
            StartCoroutine(nextLevelTransition(3));
        }

        /// <summary>
        /// Recarrega a fase atual
        /// </summary>
        public void ReloadOnDeath()
        {
            StartCoroutine(deathTransition(2));
        }

        public void LoadLevel(string levelName)
        {
            loadLevelTransition(levelName);
        }

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
            if (hasPlayer)
                if (playerStatus.isPlayerDead())
                {
                    ReloadOnDeath();
                }
        }

        private IEnumerator nextLevelTransition(float delayTime)
        {
            playerMovement.canMovePlayer = false;
            playerSoundManager.nextLevelSound();
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(nextLevel);
        }
        
        
        private IEnumerator deathTransition(float delayTime)
        {
            playerMovement.canMovePlayer = false;
            playerSoundManager.deathSoundReload();
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(actualScene.name);
        }

        private void loadLevelTransition(string levelName)
        {
            if (playerSoundManager != null)
                playerSoundManager.stopSounds();
            if (animator != null)
                animator.SetTrigger("FadeOut");// inicia o fade out
            SceneManager.LoadScene(levelName);
        }
    }
}
