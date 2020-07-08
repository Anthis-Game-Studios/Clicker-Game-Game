using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ProjectListItemConnection : MonoBehaviour
{
    public GameObject projectListItemTitle;
    public Slider projectListItemTimeSlider;

    public int guiDepth = 0;


    public GameObject mainProjectItem;
    public ProjectScript echoProjectScript;

    public float mainTimer;
    public float sliderTimer = 0;
    public bool timerIsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        mainProjectItem = ProjectListScript.projectDict.FirstOrDefault(go => go.Value == this.gameObject).Key;
        echoProjectScript = mainProjectItem.GetComponent<ProjectScript>();

        projectListItemTitle = this.gameObject.transform.GetChild(0).gameObject;
        projectListItemTitle.GetComponent<TextMeshPro>().text = echoProjectScript.projectTitle;

        projectListItemTimeSlider = this.transform.GetChild(0).transform.GetChild(1).GetComponent<Slider>();

        projectListItemTimeSlider.maxValue = mainTimer;
        //this.GetComponent<Button>().onClick.AddListener(SwitchProject());


    }

    // Update is called once per frame
    void Update()
    {
        if (mainTimer > 0 && timerIsActive)
        {
            mainTimer -= Time.deltaTime;
            projectListItemTimeSlider.value += Time.deltaTime;
        }
        else if (mainTimer < 0 && timerIsActive)
        {
            projectListItemTimeSlider.value = projectListItemTimeSlider.maxValue;
            mainTimer = 0;
        }
        else if (mainTimer == 0 && timerIsActive)
        {
            Debug.Log("test");
            echoProjectScript.ProjectComplete();
            timerIsActive = false;
        }

    }

    /// <summary>
    /// Set the current main projecthandler to this gameobject (projecthandler in the sidebar)
    /// </summary>
    public void SwitchProject()
    {
        ProjectListScript.SetCurrent(mainProjectItem);
    }
}



//    public void SetCurrent()
//    {
//        echoProjectScript.isCurrentProject = true;
//        foreach (GameObject keyItem in ProjectListScript.projectDict.Keys)
//        {
//            if (keyItem != ProjectListScript.projectDict.FirstOrDefault(go => go.Value == this.gameObject).Key)
//            {
//                keyItem.GetComponent<ProjectScript>().isCurrentProject = false;
//                keyItem.SetActive(false);
//            }
//            keyItem.GetComponent<ProjectScript>().CheckIfCurrent();
//        }
//        mainProjectItem.SetActive(true);
//    }
//}
