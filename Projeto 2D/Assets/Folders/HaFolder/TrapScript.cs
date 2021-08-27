using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapScript : MonoBehaviour
{
    public int sceneLoad;
    [SerializeField] private Element.ElementType element;
    [SerializeField] private Transform respawnPoint;
    

    public Element.ElementType GetElementType()
    {
        return element;
    }

    public void OpenTrap()
    {
        Destroy(this.gameObject);
    }

    public void KillPlayer(GameObject player)
    {
        Destroy(player);
    }

    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = respawnPoint.transform.position;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneLoad);
    }
}
