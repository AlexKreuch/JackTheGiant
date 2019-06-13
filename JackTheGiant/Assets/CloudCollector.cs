using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    private CloudManager cloudManager;
    // Start is called before the first frame update
    void Start()
    {
        cloudManager = transform.GetComponentInParent<CloudManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
