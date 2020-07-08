using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{

    public GameObject progressCounter;
    public Slider currentProgressSlider;
    public TextMeshPro progressText;
    //public float currentProgress = 0f;
    public long currentProgress = 0;

    public ProjectScript projectScript;

    public GameObject listViewProject;
    public GameObject listViewProjectText;

    //public TextMeshPro currentClickDisplay;

    //public float ability = .5f;


    void Start()
    {
        projectScript = this.gameObject.GetComponent<ProjectScript>();
        listViewProject = ProjectListScript.projectDict.FirstOrDefault(go => go.Key == this.gameObject).Value;
        listViewProjectText = listViewProject.transform.GetChild(0).transform.GetChild(0).gameObject;
        progressCounter = this.transform.GetChild(2).gameObject;
        if (currentProgress < 1)
        {
            listViewProjectText.GetComponent<TextMeshPro>().text = progressCounter.GetComponent<TextMeshPro>().text = currentProgress.ToString("0 Clicks");
        }
        else if (currentProgress == 1)
        {
            listViewProjectText.GetComponent<TextMeshPro>().text = progressCounter.GetComponent<TextMeshPro>().text = currentProgress.ToString("1 Click");
        }
        else
        {
            listViewProjectText.GetComponent<TextMeshPro>().text = progressCounter.GetComponent<TextMeshPro>().text = currentProgress.ToString("#,# Clicks");
        }
        //progressText = progressCounter.GetComponent<Text>();
        //currentProgressSlider = progressCounter.GetComponentInChildren<Slider>();

    }

    
    void Update()
    {

    }

    /// <summary>
    /// Adds clicks to the current project
    /// </summary>
    public void OnProgressClick()
    {
        if (UpgradesScript.ability > 0 && listViewProject.GetComponent<ProjectListItemConnection>().timerIsActive)
        {
            //if (currentProgress + ability > 100f)
            //{
            //    currentProgress = 100;
            //    projectScript.ProjectComplete();
            //}
            //else
            //{
               projectScript.oldClicks  += UpgradesScript.ability;
            if (projectScript.oldClicks <= 1)
            {
                listViewProjectText.GetComponent<TextMeshPro>().text = progressCounter.GetComponent<TextMeshPro>().text = projectScript.oldClicks.ToString("# Click");
            }
            else
            {
                listViewProjectText.GetComponent<TextMeshPro>().text = progressCounter.GetComponent<TextMeshPro>().text = projectScript.oldClicks.ToString("#,# Clicks");
            }

            //}
            //progressText.text = currentProgress.ToString("#.###\\% progress made");
            //currentProgressSlider.value = currentProgress;
        }
       

    }

}
