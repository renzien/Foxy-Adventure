using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public GameObject interactionCanvas;

    private void Start()
    {
        if (interactionCanvas != null)
        {
            interactionCanvas.SetActive(false);
        } 
        else
        {
            Debug.LogWarning("Belum diatur di Inspector!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionCanvas != null)
            {
                interactionCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (interactionCanvas != null)
            {
                interactionCanvas.SetActive(false);
            }
        }
    }
}