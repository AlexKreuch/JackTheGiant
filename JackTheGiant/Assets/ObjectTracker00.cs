using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracker00 : MonoBehaviour
{

    private string ObjName { get { return gameObject.name; } }

    void Start() { Debug.Log("in ObjName : Start-called"); }
    void Awake() { Debug.Log("in ObjName : Awake-called"); }
    void OnAplicationQuit() { Debug.Log("in ObjName : OnAplicationQuit-called"); }
    void OnDisable() { Debug.Log("in ObjName : OnDisable-called"); }
    void OnDestroy() { Debug.Log("in ObjName : OnDestroy-called"); }
}
