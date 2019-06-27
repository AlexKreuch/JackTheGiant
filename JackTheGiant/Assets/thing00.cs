using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing00 : MonoBehaviour
{
    void Start() { Debug.Log("in thing : Start-called"); }
    void Awake() { Debug.Log("in thing : Awake-called"); }
    void OnAplicationQuit() { Debug.Log("in thing : OnAplicationQuit-called"); }
    void OnDisable() { Debug.Log("in thing : OnDisable-called");
        GameObject.Destroy(gameObject);
    }
    void OnDestroy() { Debug.Log("in thing : OnDestroy-called"); }
    void OnEnable() { Debug.Log("in thing : OnEnable-called"); }
}
