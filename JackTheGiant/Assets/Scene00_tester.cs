using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene00_tester : MonoBehaviour
{
    public bool btn = false;
    public string dsp = "";
    private CameraMover cms;

    public float currentSpeed = 0f;
    public float speedUpFactor = 0f;
    public float maxSpeed = 0f;

    private void getVals() {
        getCMS();
        currentSpeed = cms.currentSpeed;
        speedUpFactor = cms.speedUpFactor;
        maxSpeed = cms.maxSpeed;
    }
    private void updateVals() {
        getCMS();
        if (cms.enabled)
        {
            currentSpeed = cms.currentSpeed;
            speedUpFactor = cms.speedUpFactor;
            maxSpeed = cms.maxSpeed;
        }
        else
        {
            cms.currentSpeed = currentSpeed;
            cms.speedUpFactor = speedUpFactor;
            cms.maxSpeed = maxSpeed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        getVals();
    }

    // Update is called once per frame
    void Update()
    {
        updateVals();
        if (btn)
        {
            btn_push();
            btn = false;
        }
    }
    private void btn_push() {
        getCMS();
        bool x = cms.enabled;
        cms.enabled = !x;
    }
    private void getCMS() { if(cms==null) cms = (Camera.main).GetComponent<CameraMover>(); }
}
