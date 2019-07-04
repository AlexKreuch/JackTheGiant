using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing00 : MonoBehaviour
{
    public static thing00 instance;

    public void Shout(UnityEngine.AudioClip audio) {

        AudioSource.PlayClipAtPoint(audio,new Vector3());

        
    }

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
