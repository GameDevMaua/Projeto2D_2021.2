using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField] private Element.ElementType element;

    public Element.ElementType GetElementType()
    {
        return element;
    }

    public void OpenTrap()
    {
        Destroy(this.gameObject);
    }
}
