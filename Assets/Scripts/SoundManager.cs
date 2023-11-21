using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {get; private set;}
    AudioSource _sfxAudioSource;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip boom;
    [SerializeField] private AudioClip star;

    // Start is called before the first frame update
    void Awake()
    {
        _sfxAudioSource = GetComponent<AudioSource>();

        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void DeathSound()
    {
        _sfxAudioSource.PlayOneShot(deathSound);
    }

    public void Boom()
    {
        _sfxAudioSource.PlayOneShot(boom);
    }

    public void Star()
    {
        _sfxAudioSource.PlayOneShot(star);
    }
}