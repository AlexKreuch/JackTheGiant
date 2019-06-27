using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneTester : MonoBehaviour
{
    public readonly static string SS_name = "SampleScene";
    public readonly static string SS01_name = "SampleScene_01";

    [SerializeField]
    private SpriteRenderer someThing;

    public bool btn = false;

    void Start() { Debug.Log("in SS : Start-called"); }
    void Awake() { Debug.Log("in SS : Awake-called"); }
    void OnApplicationQuit() { Debug.Log("in SS : OnApplicationQuit-called"); }
    void OnDisable() { Debug.Log("in SS : OnDisable-called"); }
    void OnDestroy() { Debug.Log("in SS : OnDestroy-called"); }

    void Update() {
        if (btn)
        {
            Push();
            btn = false;
        }
    }

    private void Push() {
        SceneManager.LoadScene(SS01_name);
    }

}
