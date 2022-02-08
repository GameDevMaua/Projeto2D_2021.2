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
        private MainProject.Scripts.Player.PlayerSoundManager playerSoundManager;
        private MainProject.Scripts.Player.PlayerMovement playerMovement;

        [SerializeField] private bool hasPlayer;

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

            if (!hasPlayer) return;
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
            StartCoroutine(transition(3));
        }

        /// <summary>
        /// Recarrega a fase atual
        /// </summary>
        public void ReloadOnDeath()
        {
            StartCoroutine(transition2(2));
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
            if (!hasPlayer) return;
            if (playerStatus.isPlayerDead())
                playerSoundManager.deathSoundReload();
            ReloadOnDeath();
        }

        private IEnumerator transition(float delayTime)
        {
            playerMovement.canMovePlayer = false;
            playerSoundManager.nextLevelSound();
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(nextLevel);
        }
        
        
        private IEnumerator transition2(float delayTime)
        {
            playerMovement.canMovePlayer = false;
            animator.SetTrigger("FadeOut");// inicia o fade out
            yield return new WaitForSeconds(delayTime);
            SceneManager.LoadScene(actualScene.name);
        }
    }
}
