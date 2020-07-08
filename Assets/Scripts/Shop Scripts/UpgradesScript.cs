using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class UpgradesScript : MonoBehaviour
{

    public static List<Upgrade> upgradesList = new List<Upgrade>();


    public static long ability = 1;

    public static int employeesPerProject = 1;

    public static int maxEmployees = 1;

    public static float extraSmallGameExtend, smallGameExtend, mediumGameExtend, largeGameExtend, extraLargeGameExtend = 1;

    public static bool smallGames, mediumGames, largeGames, extraLargeGames = false;

    public static Dropdown.OptionDataList gameSizeData;

    public CreateGameScript createGameScript;

    public Button gameSizesButton;

    //public static int upgradePrice;

    //public int maxProjectsMult;

    public int unStaticPrice;

    public void BuyUpgrade(string upgradeName)
    {
        foreach (Upgrade upgrade in upgradesList)
        {
            Debug.Log(upgradeName + " == " + upgrade.upgradeName);
            if (upgradeName == upgrade.upgradeName)
            {
                upgrade.BuyThisUpgrade();
                GameObject currentButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
                currentButton.GetComponentInChildren<Text>().text = "Upgrade " + upgradeName + Environment.NewLine + upgrade.upgradePrice;
                break;
            }
        }

    }

    /// <summary>
    /// Unlocks different "sized" games that give longer timers and adds the value to the dropdown in the create game menu
    /// </summary>
    /// <param name="gameSize">A string that determines which game size you unlock next</param>
    public void UnlockGameSizes(string gameSize)
    {
        if (gameSize == "small")
        {
            smallGames = true;
            Dropdown.OptionData optionDataS = new Dropdown.OptionData();
            optionDataS.text = "Small Game";
            gameSizeData.options.Add(optionDataS);
            gameSizesButton.GetComponentInChildren<Text>().text = "Unlock Medium Games";
            gameSizesButton.onClick.RemoveAllListeners();
            gameSizesButton.onClick.AddListener(delegate { UnlockGameSizes("medium"); });
        }
        if (gameSize == "medium")
        {
            mediumGames = true;
            Dropdown.OptionData optionDataM = new Dropdown.OptionData();
            optionDataM.text = "Medium Game";
            gameSizeData.options.Add(optionDataM);
            gameSizesButton.GetComponentInChildren<Text>().text = "Unlock Large Games";
            gameSizesButton.onClick.RemoveAllListeners();
            gameSizesButton.onClick.AddListener(delegate { UnlockGameSizes("large"); });
        }
        if (gameSize == "large")
        {
            largeGames = true;
            Dropdown.OptionData optionData = new Dropdown.OptionData();
            optionData.text = "Large Game";
            gameSizeData.options.Add(optionData);
            gameSizesButton.GetComponentInChildren<Text>().text = "Unlock Extra Large Games";
            gameSizesButton.onClick.RemoveAllListeners();
            gameSizesButton.onClick.AddListener(delegate { UnlockGameSizes("extraLarge"); });
        }
        if (gameSize == "extraLarge")
        {
            extraLargeGames = true;
            Dropdown.OptionData optionData = new Dropdown.OptionData();
            optionData.text = "Extra Large Game";
            gameSizeData.options.Add(optionData);
            gameSizesButton.GetComponentInChildren<Text>().text = "Unlocks Maxed Out";
            gameSizesButton.onClick.RemoveAllListeners();
            gameSizesButton.enabled = false;
        }
    }


    private void Awake()
    {
        Upgrade maxProjects = gameObject.AddComponent<Upgrade>();
        maxProjects.upgradeAmount = 1;
        maxProjects.upgradeName = "Max Projects";
        maxProjects.upgradePrice = 1;
        maxProjects.upgradePriceMult = 1.75f;

        upgradesList.Add(maxProjects);

        Upgrade ability = gameObject.AddComponent<Upgrade>();
        ability.upgradeAmount = 1;
        ability.upgradeName = "Ability";
        ability.upgradePrice = 1;
        ability.upgradePriceMult = 1.5f;

        upgradesList.Add(ability);

        Upgrade employeesPerProject = gameObject.AddComponent<Upgrade>();
        employeesPerProject.upgradeAmount = 1;
        employeesPerProject.upgradeName = "Employees Per Project";
        employeesPerProject.upgradePrice = 1;
        employeesPerProject.upgradePriceMult = 2.1f;

        upgradesList.Add(employeesPerProject);


        extraSmallGameExtend = 1;
        smallGameExtend = 1;
        mediumGameExtend = 1;
        largeGameExtend = 1;
        extraLargeGameExtend = 1;

        //createGameScript = GameObject.FindGameObjectWithTag("Create Button").GetComponent<CreateGameScript>();
        gameSizeData = new Dropdown.OptionDataList();
        gameSizesButton = GameObject.FindGameObjectWithTag("Unlock Game Sizes").GetComponent<Button>();
        gameSizesButton.GetComponentInChildren<Text>().text = "Unlock Small Games";
        gameSizesButton.onClick.AddListener(delegate { UnlockGameSizes("small"); });


    }

    void Update()
    {

    }
}
