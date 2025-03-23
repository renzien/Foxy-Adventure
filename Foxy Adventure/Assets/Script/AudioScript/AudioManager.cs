using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-- Audio Source --")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-- Audio Clip --")]
    public AudioClip background;
    public AudioClip attack;
    public AudioClip hit;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }
}
