using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionsMenuScript : MonoBehaviour
{

    private int difficulty=0; // 0:=Easy, 1:=Medium, 2:=Hard
    private int ValueSetter(int v) {
        Debug.Assert(v>-1 && v<3);
        difficulty = v;
        return 0;
    }

    [SerializeField]
    UnityEngine.UI.Button[] buttons;
    [SerializeField]
    UnityEngine.UI.Image[] checkSigns;

    private void RequestSetting() {
        System.Func<int, int> setter = ValueSetter;
        string message = GameManager.SceneChangeUtils.Tags.OPTIONS;
        GameManager.instance.TellManagerSomething(message,setter);
    }
    private void SendSetting() {
        string message = GameManager.SceneChangeUtils.Tags.SAVE_OPTION;
        GameManager.instance.TellManagerSomething(message,difficulty);
    }

    void Start() {
        RequestSetting();
        CheckBoxUpdate();
    }

    public void BackToMain() {
        SendSetting();
        SceneManager.LoadScene("MainMenu00");
    }
    public void PushOptionsButton(int opt){
        Debug.Assert(opt>=0 && opt<=2);
        difficulty = opt;
        CheckBoxUpdate();
    }

    private void CheckBoxUpdate() {
        /*
         * Set the Correct checkBox to 'active'
         */
        for (int i = 0; i < 3; i++)
        {
            checkSigns[i].gameObject.SetActive(i==difficulty);
        }
    }


}
