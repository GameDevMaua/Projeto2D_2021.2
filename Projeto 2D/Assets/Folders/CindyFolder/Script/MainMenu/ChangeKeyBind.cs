using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ChangeKeyBind : MonoBehaviour
{
    public GameObject changeKeyFirstButton;
    public GameObject optionMenu;
    public GameObject changeKeyMenu;
    public GameObject optionChangeKeyBindButton;
    public GameObject changeButtonImage;
    public BindKey bindKey;
    private FirstButton fb;

    /// <summary>
    /// Quando começar essa classe, chamar o optionFirstButton
    /// </summary>
    public void Start()
    {
        fb = changeKeyMenu.AddComponent<FirstButton>();
        EventSystem.current.SetSelectedGameObject(changeKeyFirstButton);
        changeKeyMenu.SetActive(true);
        optionMenu.SetActive(false);
    }

    public void LeftButton()
    {
        changeButtonImage.SetActive(true);
        bindKey.LeftButton();
    }

    /// <summary>
    /// Criação da ação do botão BACK
    /// </summary>
    public void backButton()
    {
        changeKeyMenu.SetActive(false);
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
