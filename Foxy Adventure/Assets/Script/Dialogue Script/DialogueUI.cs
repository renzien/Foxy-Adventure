using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text labelText;

    private void Start()
    {
        GetComponent<TypeEffect>().Run("Oh, Halo semua!\nIni merupakan line kedua untuk dialogue game ini.", labelText);
    }
}
