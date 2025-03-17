using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out FoxyMove player))
        {
            player.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out FoxyMove player))
        {
            if (player.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(FoxyMove player)
    {
        if (TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.DialogueObject == dialogueObject)
        {
            // Mengakses ResponseHandler dari DialogueUI
            player.DialogueUI.GetComponent<ResponseHandler>().AddResponseEvents(responseEvents.Events);
        }

        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}