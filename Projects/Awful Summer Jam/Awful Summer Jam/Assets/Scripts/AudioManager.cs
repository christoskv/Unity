using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds; // Array of type Sound (custom Class)

    public static AudioManager instance;

	private void Awake () {
        // Keep AudioManager through Scenes
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); 

        // Initializing AudioSources for each sound
		foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    private void Start()
    {
        Play("Theme"); // Play Theme song
    }

    public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Find the corresponding sound clip in Sound array
        if (s == null) // In case it doesn't find the wanted sound
        {
            Debug.LogWarning("Sound: " + name + "was not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Find the corresponding sound clip in Sound array
        if (s == null) // In case it doesn't find the wanted sound
        {
            Debug.LogWarning("Sound: " + name + "was not found");
            return;
        }
        s.source.Stop();
    }
}
