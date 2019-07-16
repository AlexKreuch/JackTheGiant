using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT00_controller : MonoBehaviour
{
    public float trackerKey = 0f;
    public int counter = 0;
    public float secondProp = 0f;

   private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
        bool found = animator != null;
        Debug.Log("animator-found = " + found);
        TEST();
    }


    // secondProp

    
    void TEST() {
        var rtac = animator.runtimeAnimatorController;
        
        var clip = rtac.animationClips[0];

        

        int eventCount = clip.events.Length;
        bool isEmpty = clip.empty;
        int curveFlags = 0;
        if (clip.hasMotionCurves) curveFlags += 4;
        if (clip.hasMotionFloatCurves) curveFlags += 2;
        if (clip.hasRootCurves) curveFlags += 1;

        Debug.Log("clip.empty = " + isEmpty);
        Debug.Log("eventCount = " + eventCount);
        Debug.Log("curveFlags [motion/motionFloat/Root] = " + curveFlags);


      

        clip.SetCurve("", typeof(AT00_controller), "secondProp", MakeCurve(60,10));
      //  clip.SetCurve("", typeof(AT00_controller), "secondProp", curve1);


    }

    AnimationCurve MakeCurve(int n, float maxVAl) {
        if (n < 1) n = 1;
        float delta_x = 1f / n;
        float delta_y = maxVAl / n;

        Keyframe[] keyframes = new Keyframe[n];
        for (int i = 0; i < n; i++)
            keyframes[i] = new Keyframe(delta_x*i,delta_y*i);

        return new AnimationCurve(keyframes);
    }
   
}
