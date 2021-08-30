using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectStatus : MonoBehaviour
{
    [SerializeField]
    private Element.ElementType objectElement; // Element type of the object
    [SerializeField]
    private bool hasActivity; // If the object is active or not

    /// <summary>
        /// Awake call for the ObjectStatus class, start variables with standard values
    /// </summary>
    protected void AwakeObjectStatus()
    {
        gameObject.SetActive(getObjectActivity());
    }

    /// <summary>
    /// Gets the element type of the current object
    /// </summary>
    /// <returns>Element.ElementType of the object</returns>
    public Element.ElementType getObjectElement() => objectElement;
    
    /// <summary>
    /// Set the object element type to the param
    /// </summary>
    /// <param name="element">Element.ElementType, desired element type of the object</param>
    public void setObjectElement(Element.ElementType element) => objectElement = element;

    /// <summary>
    /// Gets the object activity of the current object
    /// </summary>
    /// <returns>bool of the object activity</returns>
    public bool getObjectActivity() => hasActivity;
    
    /// <summary>
    /// Set the object activity to the param
    /// </summary>
    /// <param name="element">bool, desired activity of the object</param>
    public void setObjectActivity(bool status) => hasActivity = status;
}
