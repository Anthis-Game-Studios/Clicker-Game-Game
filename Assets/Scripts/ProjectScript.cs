using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine;

public class ProjectScript : MonoBehaviour
{
    public GameObject shopMenu;

    public GameObject projectCompleteWindow;

    public GameObject projectTitlePanel;
    public string projectTitle;

    public ProgressScript progressScript;

    public bool isCurrentProject = false;

    public bool isCurrentChange = true;

    public Button progressButton;

    public Button editGameButton;

    public Button releaseGameButton;

    public GameObject echoProjectObject;

    public float currentProjectTimer;

    public Slider currentProjectSlider;

    public long oldClicks = 0;

    public long clicks
    {

        get { return oldClicks; }

        set
        {
            if (clicks == oldClicks) return;
            oldClicks = clicks;
            OnVariableChange?.Invoke(oldClicks);
        }

    }

    public delegate void OnVariableChangeDelegate(long newClicks);
    public event OnVariableChangeDelegate OnVariableChange;


    void Start()
    {

        projectCompleteWindow = this.transform.GetChild(0).gameObject;
        projectCompleteWindow.SetActive(false);

        projectTitlePanel = this.transform.GetChild(1).gameObject;
        projectTitlePanel.transform.GetComponentInChildren<TextMeshPro>().text = projectTitle;

        progressScript = this.GetComponentInParent<ProgressScript>();

        isCurrentProject = true;

        progressButton = GameObject.FindGameObjectWithTag("Progress Button").GetComponent<Button>();

        editGameButton = transform.Find("Game Complete Panel").Find("Edit Details Button").GetComponent<Button>();

        releaseGameButton = transform.Find("Game Complete Panel").Find("Release Button").GetComponent<Button>();

        echoProjectObject = ProjectListScript.projectDict.FirstOrDefault(go => go.Key == this.gameObject).Value;

        currentProjectSlider = this.transform.GetChild(3).GetComponent<Slider>();


        ProjectListScript.SetCurrent(this.gameObject);


        this.OnVariableChange += VariableChangeHandler;

        

    }


    void Update()
    {
        currentProjectTimer = echoProjectObject.GetComponent<ProjectListItemConnection>().mainTimer;
        currentProjectSlider.maxValue = echoProjectObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Slider>().maxValue;
        currentProjectSlider.value = echoProjectObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Slider>().value;
    }



    public void ProjectComplete()
    {
        projectCompleteWindow.SetActive(true);
        projectCompleteWindow.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(ReleaseGame);
        projectCompleteWindow.transform.GetChild(2).GetComponent<Text>().text = projectTitle;
    }


    public void ReleaseGame()
    {
        projectCompleteWindow.SetActive(false);
    }

    /// <summary>
    /// Changes the number of clicks without putting it in the "Update()" method for performance reasons
    /// </summary>
    /// <param name="newClicks">The new number of clicks if it changes</param>
    private void VariableChangeHandler(long newClicks)
    {
        clicks = newClicks;
    }

    /// <summary>
    /// Changes where the clicks from the "Tap for progress" go
    /// </summary>
    public void CheckIfCurrent()
    {
        if (isCurrentProject && isCurrentChange)
        {
            progressButton.onClick.AddListener(progressScript.OnProgressClick);
            releaseGameButton.onClick.AddListener(ReleaseGame);
            isCurrentChange = false;
        }
        else if (!isCurrentProject)
        {
            progressButton.onClick.RemoveListener(progressScript.OnProgressClick);
            releaseGameButton.onClick.RemoveListener(ReleaseGame);
            isCurrentChange = true;
        }
    }


}
