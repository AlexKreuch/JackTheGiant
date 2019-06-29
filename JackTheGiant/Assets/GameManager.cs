using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public static GameManager instance;

    void Awake() {
        MakeInstance();
    }

    private void MakeInstance() {
        if (instance == null)
            instance = this;
        else
            GameObject.Destroy(this);
    }

    void Start() { Debug.Log("gm-started"); }

    public void HitReadyButton() {
        
    }

    public void TestGM() {
        Debug.Log("this workeed");
    }
}
