using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    private void Start()
    {
        textLabel.text = "Hello!! Froggie,\nI'm Foxy. Nice to meet you";
    }
}
