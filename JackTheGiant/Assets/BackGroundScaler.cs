using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScaler : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TEST(string input) {

        try
        {
            var item = GetComponent(input);
            Debug.Log(string.Format("{0}-found : {1}",input,item!=null));
        }
        catch {
            Debug.Log("exception-thrown");
        }
    }
}
