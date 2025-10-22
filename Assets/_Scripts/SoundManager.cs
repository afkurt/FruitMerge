using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource _audiosource;

    [Header("Sound Effects")]
    public AudioClip tada;


    private void Awake()
    {
        Instance = this;

        _audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (_audiosource == null) return;
        _audiosource.PlayOneShot(clip);
    }

    public void PlayTada() => PlaySound(tada);
    

}
