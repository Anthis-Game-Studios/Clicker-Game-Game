using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class CreateGameScript : MonoBehaviour
{
    //The canvas in the scene
    public GameObject mainCanvas;

    public GameObject secondCanvas;

    //A prefab in the Resources folder
    public GameObject projectHandler;

    //The "projectHandler" prefab after it's instantiated
    public GameObject instantiatedProjectHandler;

    public GameObject createPanel;

    //The title input object on the canvas
    public GameObject titleInputObject;

    public Dropdown sizeDropdown;

    public GameObject currentGame;

    public float x, y, z;


    void Start()
    {
        mainCanvas = GameObject.FindGameObjectWithTag("Main Canvas");
        secondCanvas = GameObject.FindGameObjectWithTag("Second Canvas");
        createPanel = GameObject.FindGameObjectWithTag("Create Panel");
        sizeDropdown = GameObject.FindGameObjectWithTag("Size Dropdown").GetComponent<Dropdown>();
        projectHandler = Resources.Load<GameObject>("ProjectHandler");
        titleInputObject = GameObject.FindGameObjectWithTag("Title Input");
        createPanel.SetActive(false);
    }

    
    void Update()
    {
        //if (instantiatedProjectHandler != null)
        //{
        //    instantiatedProjectHandler.transform.position = new Vector3(x, y, z);
        //}
        Debug.Log(sizeDropdown.value);
        
    }

    /// <summary>
    /// Opens the create game menu that sets parameters of the project
    /// </summary>
    public void StartCreatingGame()
    {
        createPanel.SetActive(true);
        if (ProjectListScript.projectDict.Count != 0)
        {
            currentGame = GameObject.FindGameObjectWithTag("Project Handler");
            currentGame.SetActive(false);
        }
        sizeDropdown.ClearOptions();
        Dropdown.OptionData optionData = new Dropdown.OptionData();
        optionData.text = "Extra Small Game";
        sizeDropdown.options.Add(optionData);
        sizeDropdown.AddOptions(UpgradesScript.gameSizeData.options);
        Debug.Log(UpgradesScript.extraSmallGameExtend);
    }

    /// <summary>
    /// Instantiates a new projecthandler using parameters from StartCreatingGame()
    /// </summary>
    public void CreateGame()
    {
        if (string.IsNullOrEmpty(titleInputObject.GetComponent<InputField>().text))
        {
            titleInputObject.transform.GetChild(1).GetComponent<Text>().text = "Title cannot be blank";
        }
        else
        {
            ProjectScript instantiatedProjectScript;
            instantiatedProjectHandler = Instantiate(projectHandler, secondCanvas.transform, false) as GameObject;

            instantiatedProjectScript = instantiatedProjectHandler.GetComponent<ProjectScript>();
            instantiatedProjectScript.projectTitle = titleInputObject.GetComponent<InputField>().text;

            ProjectListScript.CreateProjectDict(instantiatedProjectHandler, sizeDropdown.value);

            GameObject instantiatedProjectListView = ProjectListScript.projectDict.FirstOrDefault(go => go.Key == instantiatedProjectHandler).Value;


            titleInputObject.GetComponent<InputField>().text = "";
            titleInputObject.transform.GetChild(1).GetComponent<Text>().text = "Enter Game Title";
            createPanel.SetActive(false);
        }

    }

    /// <summary>
    /// Closes create game menu
    /// </summary>
    public void CancelGame()
    {
        titleInputObject.GetComponent<InputField>().text = "";
        titleInputObject.transform.GetChild(1).GetComponent<Text>().text = "Enter Game Title";
        createPanel.SetActive(false);
        if (ProjectListScript.projectDict.Count != 0)
        {
            currentGame.SetActive(true);
        }
        Debug.Log("Wtf");
    }
}
