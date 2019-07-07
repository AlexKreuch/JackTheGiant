using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing00 : MonoBehaviour
{
    public static thing00 instance;
    public static int counter = -1;

    private void Report(string s, params object[] args) {
        Debug.Log(string.Format(s,args));
    }
    private void Report() { Debug.Log(""); }

    void Awake()
    {
        counter++;
        Report("{0} | OnAwake-called",counter);
        MakeInstance();
        Report("{0} | made it here",counter);
    }

    private void MakeInstance() {
        Report("{0} | MakeInstance-called",counter);
        if (instance == null)
        {
            Report("{0} | no-instance found ; must be set", counter);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Report("{0} | instance already there ; must be destroyed",counter);
            Destroy(gameObject);
        }
    }


   
    
}
