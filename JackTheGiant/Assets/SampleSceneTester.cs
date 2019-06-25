using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleSceneTester : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject Col;
    public int in_num = 0;
    public string dsp;

    public bool btn = false;
    

    // Update is called once per frame
    void Update()
    {
        if (btn)
        {
            Push();
            btn = false;
        }
    }

    private void Push() {
        if (in_num < 0 || in_num >= gameObjects.Length)
        {
            dsp = "invalid-index";
        }
        else if (dsp == "mk") gameObjects[in_num] = Instantiate(Col);
        else
        {
            if (gameObjects[in_num] == null) { dsp = "not-found"; return; }
            bool b0 = false;
            switch (dsp)
            {
                case "toggle":
                    b0 = !gameObjects[in_num].activeSelf;
                    gameObjects[in_num].SetActive(b0);
                    break;
                case "kill":
                    GameObject.Destroy(gameObjects[in_num]);
                    break;
                default: dsp = "???"; break;
            }
        }

    }
}
