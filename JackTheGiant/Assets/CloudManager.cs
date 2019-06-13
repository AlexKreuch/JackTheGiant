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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
