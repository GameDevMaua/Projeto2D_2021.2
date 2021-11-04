using UnityEngine;

namespace MainProject.Scripts.DialogueSystem
{
    /// <summary>
    /// Cria o ScriptableObject CharacterProfile, que contém as informações dos personagens no diálogo
    /// </summary>
    [CreateAssetMenu(fileName = "Main NewProfile", menuName = "Main CharacterProfile")]
    public class CharacterProfile : ScriptableObject
    {
        public string Name;
        public Sprite Image;
    }
}