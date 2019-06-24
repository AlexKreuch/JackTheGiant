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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "cloud" || other.tag == "cloud_dark")
        {
            GameObject.Destroy(other.gameObject);
            cloudManager.ReportClouds(-1);
            other.name = "asdf";
            Debug.Log("cloud-collected");
        }
    }
}
