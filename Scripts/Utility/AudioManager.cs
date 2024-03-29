using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //TODO: Add ability to have list of audio sources and audio clips
    public AudioSource source;

    void Awake()
    {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        //source = new AudioSource();
    }

    public void SetAudioSource(AudioSource audioSource)
    {
        source = audioSource;
    }

    public void SetClip(AudioClip clip)
    {
        source.clip = clip;
    }

    public void SetLooping(bool looping)
    {
        source.loop = looping;
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }

    public bool IsPlayingThisClip(AudioClip clip)
    {
        return source.isPlaying && source.clip == clip;
    }

    public void SetOnAwake(bool playOnAwake)
    {
        source.playOnAwake = playOnAwake; 
    }

    public void SetMute(bool muted)
    {
        source.mute = muted;
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }

    public void PlayClip(bool isOneShot)
    {
        if(source.clip == null)
        {
            Debug.LogError("Error: No audio clip");
            return;
        }
        
        if(isOneShot)
        {
            PlayClipOneShot();
            return;
        }
        
        source.Play();      
    }

    private void PlayClipOneShot()
    {
        if (source.clip == null)
        {
            Debug.LogError("Error: No audio clip");
        }
        else
        {
            source.PlayOneShot(source.clip);
        }
    }


}
