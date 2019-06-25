using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Collectibles collectibles;
    private bool isStarted = false;
    private bool hasBeenDisabled = false; // use this to ensure item can be disabled and re-enabled exactly ONCE int its lifetime
    private bool hasBeenSet = false;
    public bool IsStarted { get { return isStarted; } private set { isStarted = value; } }
   

    public void Init(Collectibles host) {
        if (isStarted || (host==null)) return;
        collectibles = host;
        isStarted = true;
    }


    void OnEnable() {
        if (isStarted) collectibles.SetUpCollectable(this);
    }
    void OnDisable() {
        if (hasBeenDisabled)
        {
            if(isStarted) collectibles.ReportDestruction(gameObject);
            GameObject.Destroy(gameObject);
        }
        else hasBeenDisabled = true;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        switch (collider.tag)
        {
            case "cldSpawner": gameObject.SetActive(true); break;
            case "cldCollector": gameObject.SetActive(false); break;
        }
    }

    public void SetVals(Sprite sprite, string tag) {
        if (hasBeenSet) return;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
        gameObject.tag = tag;
        hasBeenSet = true;
    }
}
