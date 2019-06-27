using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SS_01_tester : MonoBehaviour
{
    public readonly static string SS_name = "SampleScene";
    public readonly static string SS01_name = "SampleScene_01";

    public bool btn = false;

    void Start() { Debug.Log("in SS01 : Start-called"); }
    void Awake() { Debug.Log("in SS01 : Awake-called"); }
    void OnApplicationQuit() { Debug.Log("in SS01 : OnApplicationQuit-called"); }
    void OnDisable() { Debug.Log("in SS01 : OnDisable-called"); }
    void OnDestroy() { Debug.Log("in SS01 : OnDestroy-called"); }

    void Update()
    {
        if (btn)
        {
            Push();
            btn = false;
        }
    }

    private void Push()
    {
        SceneManager.LoadScene(SS_name);
    }
}
