using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text labelText;

    private void Start()
    {
        labelText.text = "Hello! Mr. Froggy\nHow are you doing today?";
    }
}
