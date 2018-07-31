using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

    Button button;
    public string pressedButton;
    public GameObject yellow;
    public GameObject credits;
    public GameObject controls;
    bool triggeredCredits = true;
    bool triggeredControls = true;

    void Start()
    {
        GameObject yellow = GetComponent<GameObject>();
        GameObject credits = GetComponent<GameObject>();
        GameObject controls = GetComponent<GameObject>();
        Button pressedButton = GetComponent<Button>();
        pressedButton.onClick.AddListener(TaskOnClick);


    }

    void TaskOnClick()
    {
        switch (pressedButton)
        {
            case "DiveIn":
                SceneManager.LoadScene("SubmarineGame");
                break;
            case "credits":
                if (triggeredCredits) {
                    yellow.SetActive(false);
                    credits.SetActive(true);
                    triggeredCredits = false;
                }
                else if (triggeredControls == true)
                {
                    yellow.SetActive(true);
                    controls.SetActive(false);
                    credits.SetActive(false);
                    triggeredControls = true;
                    triggeredCredits = true;
                }

                else
                {
                    yellow.SetActive(true);
                    credits.SetActive(false);
                    triggeredCredits = true;
                }
                break;
            case "Controls":
                if (triggeredControls)
                {
                    yellow.SetActive(false);
                    controls.SetActive(true);
                    triggeredControls = false;
                }
                else if (triggeredCredits == true) {
                    yellow.SetActive(true);
                    controls.SetActive(false);
                    credits.SetActive(false);
                    triggeredControls = true;
                    triggeredCredits = true;
                }

                else
                {
                    yellow.SetActive(true);
                    controls.SetActive(false);
                    triggeredControls = true;
                }
                break;
            case "Get Out":
                Application.Quit();
                break;
            case "Escape":
                SceneManager.LoadScene("MainScreen");
                break;
            default:
                print(pressedButton);
                break;
        }
    }

}
