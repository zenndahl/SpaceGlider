using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound{

    public string name;
    public AudioClip clip;

    [Range(0f,0.5f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
}
