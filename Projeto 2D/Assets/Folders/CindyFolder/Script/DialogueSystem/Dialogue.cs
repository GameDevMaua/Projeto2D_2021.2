using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class Dialogue:ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public CharacterProfile characterprofile;
        [TextArea(3,10)]
        public string sentences;
    }

    public Info[] dialogueInfo;

}