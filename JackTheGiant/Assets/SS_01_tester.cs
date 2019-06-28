using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SS_01_tester : MonoBehaviour
{

    [SerializeField]
    private GameObject thing;

    public float spd = 1f;

    private class TimeTracker {
        private float t;
        public TimeTracker() { t = 0f; }
        public void Step() { t += Time.deltaTime; }
        public float GetCurrent() { return t; }
    }
    TimeTracker tracker = new TimeTracker();


    
    public bool countDwn = false;
    public int cd_disp = 0;

    void Update() {
        tracker.Step();
        CheckForPush(DoCountDown, ref countDwn);
        Asdf();
    }

    private void CheckForPush(System.Func<int> method, ref bool sudoButton) {
        if (sudoButton)
        {
            method();
            sudoButton = false;
        }
    }

    private int DoCountDown() {
        IEnumerator enumerator() {
            for (cd_disp = 10; cd_disp > 0; cd_disp--)
            {
                yield return new WaitForSeconds(1f);
            }
        }

        StartCoroutine(enumerator());
        return 0;
    }

    
    private void Asdf() {
        var alpha = Mathf.Sin(spd * tracker.GetCurrent());
        alpha = (alpha + 1) / 2;
        SetColorAlpha(alpha);
    }

    private void SetColorAlpha(float alpha)
    {
        SpriteRenderer sr = thing.GetComponent<SpriteRenderer>();
        var color = sr.color;
        color.a = alpha;
        sr.color = color;
    }
    

}
