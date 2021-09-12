using UnityEngine;

/// <summary>
/// Cria o ScriptableObject CharacterProfile, que contém as informações dos personagens no diálogo
/// </summary>
[CreateAssetMenu(fileName = "NewProfile", menuName = "CharacterProfile")]
public class CharacterProfile : ScriptableObject
{
    public string Name;
    public Sprite Image;
}

