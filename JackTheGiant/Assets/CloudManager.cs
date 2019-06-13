using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    private CloudCollector cloudCollector;
    private CloudSpawner cloudSpawner;
    // Start is called before the first frame update
    void Start()
    {
        cloudSpawner = GetComponentInChildren<CloudSpawner>();
        cloudCollector = GetComponentInChildren<CloudCollector>();
        int c = 0;
        if (cloudCollector != null) c++;
        if (cloudSpawner != null) c += 2;
        Debug.Log("s/c code == " + c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
