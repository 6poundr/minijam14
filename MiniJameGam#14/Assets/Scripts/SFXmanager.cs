using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXmanager : MonoBehaviour

{
    public static SFXmanager Instance;
     public AudioSource SnakeSound;
    public AudioSource GameOverSound;

    void Awake()
    {
        Instance = this;
    }
    public void PlaySnakeSound()
    {
        SnakeSound.Play();
    }

    public void  PlayGameOverSound()
    {
        GameOverSound.Play();
    }
}
