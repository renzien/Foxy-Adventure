using UnityEngine;

[System.Serializable]
public class Response
{
    [SerializeField] private string textResponse;
    [SerializeField] private DialogueObject dialogueObject;

    public string ResponseText => textResponse;
    public DialogueObject DialogueObject => dialogueObject;
}
