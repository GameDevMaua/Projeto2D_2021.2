using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class Dialogue:ScriptableObject
{
    /// <summary>
    /// Cria o ScriptableObject com os diálogos
    /// </summary>
    [System.Serializable]
    public class Info
    {
        public GameObject indialoguecharacter;
        public CharacterProfile characterprofile; // O profile do personagem
        [TextArea(3,10)] // O tamanho do texto do diálogo
        public string sentences; // O texto do diálogo
    }

    public Info[] dialogueInfo; // Coloca as informações da classe Info em um array

}