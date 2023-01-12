using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = new AudioSource();
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }

    public void SetClip(AudioClip clip)
    {
        source.clip = clip;
    }

    public void SetLooping(bool looping)
    {
        source.loop = looping;
    }

    public void SetMute(bool muted)
    {
        source.mute = muted;
    }

    public void PlayCLip()
    {
        if(source.clip == null)
        {
            Debug.LogError("Error: No audio clip");
        }
        else
        {
            source.Play();
        }
    }

    public void SetAudioSource( AudioSource audioSource)
    {
        source = audioSource;
    }

    public void PlayClipOneShot()
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
