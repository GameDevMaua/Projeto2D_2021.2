using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private ElementType element;
    public enum ElementType
    {
        NONE,
        GEO,
        HYDRO,
        ELECTRO,
        PYRO 
    }

    public ElementType GetElementType()
    {
        return element;
    }
}
