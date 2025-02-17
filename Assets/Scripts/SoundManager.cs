using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip musicClip;
    public AudioClip clickSound; 
    public AudioClip popSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip speechSound;
    
    // Volume settings for individual sounds
    [Range(0f, 1f)] private float musicClipVolume = 0.8f;
    [Range(0f, 1f)] private float clickSoundVolume = 1f;
    [Range(0f, 1f)] private float popSoundVolume = 1.5f;
    [Range(0f, 1f)] private float winSoundVolume = 1f;
    [Range(0f, 1f)] private float loseSoundVolume = 2f;
    [Range(0f, 1f)] private float speechSoundVolume = 0.4f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (musicClip != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
            audioSource.volume = musicClipVolume;
        }
        else
        {
            Debug.LogError("Sem Música");
        }
    }

    public void ClickSound(){ audioSource.PlayOneShot(clickSound, clickSoundVolume); }
    public void PopSound(){ audioSource.PlayOneShot(popSound, popSoundVolume); }
    public void WinSound(){ audioSource.PlayOneShot(winSound, winSoundVolume); }
    public void LoseSound(){ audioSource.PlayOneShot(loseSound, loseSoundVolume); }
    public void SpeechSound(){ audioSource.PlayOneShot(speechSound, speechSoundVolume); }
}
