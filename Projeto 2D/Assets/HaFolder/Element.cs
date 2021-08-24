using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private ElementType element;
    public enum ElementType
    {
        None,
        GEO,
        HYDRO,
        ELECTRO,
        PYRO 
    }
}
