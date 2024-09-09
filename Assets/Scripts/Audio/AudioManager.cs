using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float pitch;
    public Sound[] sounds;
    public static AudioManager instance;

    void Awake() {
        if (instance == null) 
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //Play("quack")
        //or FindObjectOfType<AudioManager>().Play("Soundname");
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            if (s.name == "note")
            {
                s.source.pitch = pitch;
            }
            s.source.Play();
        } 
        else
        {
            Debug.LogWarning("Could not find sound: " + name);
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s !=null)
        {
            s.source.Stop();
        } 
        else
        {
            Debug.LogWarning("Could not find sound: " + name);
        }
    }
}
