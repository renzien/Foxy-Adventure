using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [System.Serializable]
    public class DialogueEntry
    {
        [TextArea] public string Text; // Teks dialog
        public string SpeakerName; // Nama pembicara
        public Sprite SpeakerImage; // Gambar pembicara
    }

    public DialogueEntry[] Dialogue; // Array dialog

    [SerializeField] private Response[] responses;

    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}