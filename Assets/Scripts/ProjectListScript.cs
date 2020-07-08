using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ProjectListScript : MonoBehaviour
{
    public static GameObject projectDictObject;

    public static Dictionary<GameObject, GameObject> projectDict;
    public static List<GameObject> dictKeys;
    public static List<GameObject> dictValues;

    public static GameObject projectDictContent;

    public static int numOfProjects;

    // Start is called before the first frame update
    void Start()
    {
        projectDictObject = Resources.Load<GameObject>("ProjectListItem") as GameObject;
        projectDict = new Dictionary<GameObject, GameObject>();
        projectDictContent = GameObject.FindGameObjectWithTag("Project List Content");
        dictKeys = new List<GameObject>(projectDict.Keys);
        dictValues = new List<GameObject>(projectDict.Values);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Creates a connection between the main projecthandler and the one in the sidebar
    /// </summary>
    /// <param name="project">The main projecthandler, not the one in the sidebar</param>
    /// <param name="dropdown">Value from dropdown in the create game menu</param>
    public static void CreateProjectDict(GameObject project, float dropdown)
    {
        GameObject projectDictView = Instantiate(projectDictObject, projectDictContent.transform);

        ProjectListItemConnection projectDictViewScript = projectDictView.GetComponent<ProjectListItemConnection>();

        if (dropdown == 0)
        {
            projectDictViewScript.mainTimer = 60f * UpgradesScript.extraSmallGameExtend;
        }
        if (dropdown == 1)
        {
            projectDictViewScript.mainTimer = 300f * UpgradesScript.smallGameExtend;
        }
        if (dropdown == 2)
        {
            projectDictViewScript.mainTimer = 900f * UpgradesScript.mediumGameExtend;
        }
        if (dropdown == 3)
        {
            projectDictViewScript.mainTimer = 1800f * UpgradesScript.largeGameExtend;
        }
        if (dropdown == 4)
        {
            projectDictViewScript.mainTimer = 3600f * UpgradesScript.extraLargeGameExtend;
        }

        projectDict.Add(project, projectDictView);
        dictKeys.Add(project);
        dictValues.Add(projectDictView);
        //progressSlider.transform.parent = projectDictContent.transform;
        //progressSlider.transform.localScale = new Vector3(1f, 1f, 1f);

    }
    


    public static void SetCurrent(GameObject projectKey)
    {
        projectKey.GetComponent<ProjectScript>().isCurrentProject = true;
        foreach (GameObject keyItem in projectDict.Keys)
        {
            if (keyItem != projectKey)
            {
                keyItem.GetComponent<ProjectScript>().isCurrentProject = false;
                keyItem.SetActive(false);
            }
            keyItem.GetComponent<ProjectScript>().CheckIfCurrent();
        }
        projectKey.SetActive(true);
    }
}

