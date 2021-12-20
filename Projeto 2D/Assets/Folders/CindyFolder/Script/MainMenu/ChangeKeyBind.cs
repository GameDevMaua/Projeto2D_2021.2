using UnityEngine;
using UnityEngine.EventSystems;


public class ChangeKeyBind : MonoBehaviour
{
    public GameObject changeKeyFirstButton;
    public GameObject optionMenu;
    public GameObject optionChangeKeyBindButton;
    public GameObject changeKeyImage;
    private BindKey bindKey;
    private FirstButton fb;

    /// <summary>
    /// Quando começar essa classe, chamar o optionFirstButton
    /// </summary>
    public void Start()
    {
        bindKey = changeKeyImage.GetComponent<BindKey>();
        fb = this.gameObject.AddComponent<FirstButton>();
        EventSystem.current.SetSelectedGameObject(changeKeyFirstButton);
        this.gameObject.SetActive(true);
        optionMenu.SetActive(false);
        
        // Pre-definir o texto do lado do botao para o left
        bindKey.LeftText.text = bindKey.prefabPlayerMovement.LeftKey.ToString();
        if(bindKey.prefabPlayerMovement.LeftKey == KeyCode.None) 
            bindKey.LeftText.text = KeyCode.A.ToString();
        
        // Pre-definir o texto do lado do botao para o right
        bindKey.RightText.text = bindKey.prefabPlayerMovement.RightKey.ToString();
        if(bindKey.prefabPlayerMovement.RightKey == KeyCode.None) 
            bindKey.RightText.text = KeyCode.D.ToString();
        
        // Pre-definir o texto do lado do botao para o up
        bindKey.UpText.text = bindKey.prefabPlayerMovement.UpKey.ToString();
        if(bindKey.prefabPlayerMovement.UpKey == KeyCode.None) 
            bindKey.UpText.text = KeyCode.W.ToString();
        
        // Pre-definir o texto do lado do botao para o down
        bindKey.DownText.text = bindKey.prefabPlayerMovement.DownKey.ToString();
        if(bindKey.prefabPlayerMovement.DownKey == KeyCode.None) 
            bindKey.DownText.text = KeyCode.S.ToString();
    }

    /// <summary>
    /// Quando pressionar esse botao, não permitir que navegue nos botoes, ativa uma imagem e execute a funcao
    /// </summary>
    public void LeftButton()
    {
        changeKeyImage.SetActive(true);
        bindKey.LeftButton();
    }
    
    /// <summary>
    /// Quando pressionar esse botao, não permitir que navegue nos botoes, ativa uma imagem e execute a funcao
    /// </summary>
    public void RightButton()
    {
        changeKeyImage.SetActive(true);
        bindKey.RightButton();
    }
    
    /// <summary>
    /// Quando pressionar esse botao, não permitir que navegue nos botoes, ativa uma imagem e execute a funcao
    /// </summary>
    public void UpButton()
    {
        changeKeyImage.SetActive(true);
        bindKey.UpButton();
    }
    
    /// <summary>
    /// Quando pressionar esse botao, não permitir que navegue nos botoes, ativa uma imagem e execute a funcao
    /// </summary>
    public void DownButton()
    {
        changeKeyImage.SetActive(true);
        bindKey.DownButton();
    }

    /// <summary>
    /// Quando pressionar esse botao, transformar as chaves em um default. E o texto do lado condiz com esse default
    /// </summary>
    public void DefaultButton()
    {
        bindKey.prefabPlayerMovement.ChangeLeftKey(KeyCode.A);
        bindKey.prefabPlayerMovement.ChangeRightKey(KeyCode.D);
        bindKey.prefabPlayerMovement.ChangeDownKey(KeyCode.S);
        bindKey.prefabPlayerMovement.ChangeUpKey(KeyCode.W);
        
        bindKey.playerMovement.ChangeLeftKey(bindKey.prefabPlayerMovement.LeftKey);
        bindKey.playerMovement.ChangeRightKey(bindKey.prefabPlayerMovement.RightKey);
        bindKey.playerMovement.ChangeUpKey(bindKey.prefabPlayerMovement.UpKey);
        bindKey.playerMovement.ChangeDownKey(bindKey.prefabPlayerMovement.DownKey);
                    
        bindKey.LeftText.text = bindKey.prefabPlayerMovement.LeftKey.ToString();
        bindKey.RightText.text = bindKey.prefabPlayerMovement.RightKey.ToString();
        bindKey.UpText.text = bindKey.prefabPlayerMovement.UpKey.ToString();
        bindKey.DownText.text = bindKey.prefabPlayerMovement.DownKey.ToString();
    }
    
    /// <summary>
    /// Criação da ação do botão BACK
    /// </summary>
    public void backButton()
    {
        this.gameObject.SetActive(false);
        optionMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionChangeKeyBindButton);
    }

    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        fb.SelectFirstButton(changeKeyFirstButton);
    }
}
