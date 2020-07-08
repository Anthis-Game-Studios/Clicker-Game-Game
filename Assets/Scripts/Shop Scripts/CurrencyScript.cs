using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    public static long playerMoney;

    public static Text moneyCount;
    

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 0;
        moneyCount = this.transform.GetChild(1).gameObject.GetComponent<Text>();
        moneyCount.text = playerMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        playerMoney += moneyToAdd;
        moneyCount.text = playerMoney.ToString();
    }

    public static void SubtractMoney(long moneyToSubtract)
    {
        if (playerMoney - moneyToSubtract < 0)
        {
            Debug.Log("You don't have enough money");
        }
        else
        {
            playerMoney -= moneyToSubtract;
            moneyCount.text = playerMoney.ToString();
        }


    }
}
