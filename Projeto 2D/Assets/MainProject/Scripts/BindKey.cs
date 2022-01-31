#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace MainProject.Scripts
{
    public class BindKey : MonoBehaviour
{
    public MainProject.Scripts.ChangeKeyBind changeKeyBind;
    private KeyCode [] key;
    public MainProject.Scripts.Player.PlayerMovement prefabPlayerMovement;
    public MainProject.Scripts.Player.PlayerMovement playerMovement;
    public GameObject prefab;
    public int i = 0;
    private Button button;
    public Text LeftText;
    public Text RightText;
    public Text UpText;
    public Text DownText;
    
    public enum Button {LEFT, RIGHT, UP, DOWN};

    /// <summary>
    /// Quando chamado esse função, executa o update para o enum left
    /// </summary>
    public void LeftButton()
    {
        button = Button.LEFT;
        i = 0;
        key = new KeyCode[2];
    }
    
    /// <summary>
    /// Quando chamado esse função, executa o update para o enum right
    /// </summary>
    public void RightButton()
    {
        button = Button.RIGHT;
        i = 0;
        key = new KeyCode[2];
    }
    
    /// <summary>
    /// Quando chamado esse função, executa o update para o enum up
    /// </summary>
    public void UpButton()
    {
        button = Button.UP;
        i = 0;
        key = new KeyCode[2];
    }
    
    /// <summary>
    /// Quando chamado esse função, executa o update para o enum down
    /// </summary>
    public void DownButton()
    {
        button = Button.DOWN;
        i = 0;
        key = new KeyCode[2];
    }
    

    // Update is called once per frame
    private void Update( )
    {
        // Toda vez que aperta em uma tecla, ele atribui a key dentro de key[i]
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKeyDown(vKey))
            {
                key[i] = vKey;

                // Caso o enum seja left, muda o prefab para a tecla apertada e coloca no texto esse valor
                if (button == Button.LEFT)
                {
                    prefabPlayerMovement.ChangeLeftKey(key[i]);
                    LeftText.text = prefabPlayerMovement.LeftKey.ToString();
                    playerMovement.ChangeLeftKey(prefabPlayerMovement.LeftKey);
                }

                // Caso o enum seja right, muda o prefab para a tecla apertada e coloca no texto esse valor
                if (button == Button.RIGHT)
                { 
                    prefabPlayerMovement.ChangeRightKey(key[i]);
                    RightText.text = prefabPlayerMovement.RightKey.ToString();
                    playerMovement.ChangeRightKey(prefabPlayerMovement.RightKey);
                }

                // Caso o enum seja up, muda o prefab para a tecla apertada e coloca no texto esse valor
                if (button == Button.UP)
                {
                    prefabPlayerMovement.ChangeUpKey(key[i]);
                    UpText.text = prefabPlayerMovement.UpKey.ToString();
                    playerMovement.ChangeUpKey(prefabPlayerMovement.UpKey);
                }

                // Caso o enum seja down, muda o prefab para a tecla apertada e coloca no texto esse valor
                if (button == Button.DOWN)
                {
                    prefabPlayerMovement.ChangeDownKey(key[i]);
                    DownText.text = prefabPlayerMovement.DownKey.ToString();
                    playerMovement.ChangeDownKey(prefabPlayerMovement.DownKey);
                }
                #if UNITY_EDITOR
                // Muda o prefab inteiro e todas as instancias
                PrefabUtility.RecordPrefabInstancePropertyModifications(prefab);
                i++;
                #endif
            }
            
        }
    }
}
}