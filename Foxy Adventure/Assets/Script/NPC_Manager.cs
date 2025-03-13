using UnityEngine;

public class NPC_Manager : MonoBehaviour
{
    public DialogueUI DialogueUI => dialogueUI;
    [SerializeField] private DialogueUI dialogueUI;

    private void Update()
    {
        if (dialogueUI.IsOpen) return;
    }
}
