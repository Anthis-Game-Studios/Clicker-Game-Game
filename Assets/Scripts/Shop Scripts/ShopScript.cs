using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject shopMenu;

    // Start is called before the first frame update
    void Start()
    {
        shopMenu = GameObject.FindGameObjectWithTag("Shop Menu");
        shopMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCloseShop()
    {
        if (shopMenu.activeInHierarchy)
        {
            shopMenu.SetActive(false);
        }
        else
        {
            shopMenu.SetActive(true);
            shopMenu.transform.SetAsLastSibling();
        }
    }
}
