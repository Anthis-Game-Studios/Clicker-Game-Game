using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{
    public static int maxProjects = 3;

    public static long ability = 1;

    public static int employeesPerProject = 1;

    public int projectValues;

    public int employeesValues;


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

    public void Upgrade(string upgradeType)
    {
        if (upgradeType == "maxProjects") maxProjects += 1;
        else if (upgradeType == "ability") ability += 1;
        else if (upgradeType == "employeesPerProject") employeesPerProject += 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        projectValues = maxProjects;
        employeesValues = employeesPerProject;
    }
}
