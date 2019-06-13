using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    private CloudCollector cloudCollector;
    private CloudSpawner cloudSpawner;
    private int cloudCount = 0;
    [SerializeField]
    

    public int CloudCount { get { return cloudCount; } }

    public void ReportClouds(int delta) { cloudCount += delta; }

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
