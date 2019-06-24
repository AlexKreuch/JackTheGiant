using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    private CloudCollector cloudCollector;
    private CloudSpawner cloudSpawner;
    private int cloudCount = 0;
    

    public int CloudCount { get { return cloudCount; } }

    public void ReportClouds(int delta) { cloudCount += delta; }

    // Start is called before the first frame update
    void Start()
    {
        cloudSpawner = GetComponentInChildren<CloudSpawner>();
        cloudCollector = GetComponentInChildren<CloudCollector>();
        AdjustScales();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AdjustScales() {
        var x = 2 * Camera.main.rect.width * Screen.width * (Camera.main.orthographicSize / Screen.height);
        Vector3 v = cloudCollector.transform.localScale;
        v.x = x;
        cloudCollector.transform.localScale = v;
        cloudSpawner.transform.localScale = v;

    }
}
