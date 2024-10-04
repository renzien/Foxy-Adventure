using UnityEngine;

[CreateAssetMenu (menuName = "Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
   [SerializeField] [TextArea] private string[] dialogue;

   public string[] Dialogue => dialogue;
}
