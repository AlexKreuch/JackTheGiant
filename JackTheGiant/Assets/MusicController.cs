using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    
    private AudioSource audioSource;
   

    void OnEnable() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public bool Play() { return audioSource.isPlaying; }
    public void SetPlay(bool play)
    {
        int c = play ? 1 : 0;
        if (audioSource.isPlaying) c += 2;
        switch (c)
        {
            case 1: audioSource.Play(); break;
            case 2: audioSource.Stop(); break;
        }
    }


}
