using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectStatus : MonoBehaviour
{
    [SerializeField]
    private Element.ElementType objectElement; // Tipo elemental do objeto
    [SerializeField]
    private bool hasActivity; // Se o objeto está ativo ou não

    /// <summary>
    /// Chamada do Awake para a classe ObjectStatus, incializa variáveis com valores padrões
    /// </summary>
    protected void AwakeObjectStatus()
    {
        gameObject.SetActive(getObjectActivity());
    }

    /// <summary>
    /// Lê o tipo elemental do objeto
    /// </summary>
    /// <returns>Element.ElementType, tipo elemental do objeto</returns>
    public Element.ElementType getObjectElement() => objectElement;
    
    /// <summary>
    /// Define o tipo elemental do objeto como o passado por parâmetro
    /// </summary>
    /// <param name="element">Element.ElementType, tipo elemental desejado do objeto</param>
    public void setObjectElement(Element.ElementType element) => objectElement = element;

    /// <summary>
    /// Lê a atividade do objeto
    /// </summary>
    /// <returns>bool, atividade do objeto</returns>
    public bool getObjectActivity() => hasActivity;
    
    /// <summary>
    /// Define a atividade do objeto como a passada por parâmetro
    /// </summary>
    /// <param name="element">bool, atividade desejada para o objeto</param>
    public void setObjectActivity(bool status) => hasActivity = status;
}
