using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeName;

    public long upgradeAmount;

    public long upgradePrice;

    public float upgradePriceMult;

    public void BuyThisUpgrade()
    {
        
        if (upgradeAmount == 1)
        {
        upgradePrice = Mathf.CeilToInt(Mathf.Pow(upgradeAmount, upgradePriceMult));
        }

        Debug.Log("yah");

        if (upgradePrice <= CurrencyScript.playerMoney)
        {
            upgradeAmount += 1;
            CurrencyScript.SubtractMoney(upgradePrice);
            upgradePrice = Mathf.CeilToInt(Mathf.Pow(upgradeAmount, upgradePriceMult));
            upgradePriceMult += .015f;
            Debug.Log("yeet");
        }

        if (upgradeName == "Ability")
        {
            UpgradesScript.ability = upgradeAmount;
        }
    }

    private void Awake()
    {
        if (upgradeName == "Ability")
        {
            UpgradesScript.ability = upgradeAmount;
        }
    }

    private void Update()
    {
    }

}
