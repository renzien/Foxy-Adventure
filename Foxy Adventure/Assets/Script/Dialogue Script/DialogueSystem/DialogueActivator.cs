using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interactable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter2D (Collider2D other)
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
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
