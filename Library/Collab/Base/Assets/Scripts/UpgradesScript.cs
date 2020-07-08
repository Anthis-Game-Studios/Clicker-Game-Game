using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{
    public static int maxProjects = 3;

    public int values;

    public static long ability = 1;

    public static int employeesPerProject = 1;

    public void UpgradeAbility()
    {
        ability += 1;
    }

    public void UpgradeMaxProjects()
    {
        maxProjects += 1;
    }

    public void UpgradeEmployees()
    {
        employeesPerProject += 1;
    }

    public void Upgrade(string variableName)
    {
        if (variableName == "maxProjects")
        {
            maxProjects += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        values = maxProjects;
    }
}
