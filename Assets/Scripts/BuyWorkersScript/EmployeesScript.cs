using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;





public class EmployeesScript : MonoBehaviour
{

    


    // Start is called before the first frame update
    void Start()
    {
        
        
        

        
        UnityEngine.Object button2 = GameObject.Find("Employee2").GetComponentInChildren<Text>();
        UnityEngine.Object button3 = GameObject.Find("Employee3").GetComponentInChildren<Text>();
        //var Employee1 = button1.GetComponentsInChildren(Text);



        string[] ArrayNames =
            { "Sofia Johannsen",
                "Omer Lagace",
                "Ethyl Bickett",
                "Davis Carlen",
                "Gayla Furlong",
                "Deloris Berta",
                "Erwin Twitchell",
                "Mirian Knutsen",
                "Liana Pando",
                "Debroah Folkerts",
                "Amalia Feggins",
                "Hayley Baudoin",
                "Lyndsay Tidmore",
                "Elenora Rusnak",
                "Sanda Twitty",
                "Hanh Beerman",
                "Delmar Mullinax",
                "Carolyn Vanallen",
                "Janise Bergh",
                "Neda Relyea"
 };
        //Creates random object
        System.Random rand = new System.Random();
        //Generates 9 random index's smaller than the array
        int index1 = rand.Next(ArrayNames.Length);
        int index2 = rand.Next(ArrayNames.Length);
        int index3 = rand.Next(ArrayNames.Length);
        int index4= rand.Next(ArrayNames.Length);
        int index5 = rand.Next(ArrayNames.Length);
        int index6 = rand.Next(ArrayNames.Length);
        int index7 = rand.Next(ArrayNames.Length);
        int index8 = rand.Next(ArrayNames.Length);
        int index9 = rand.Next(ArrayNames.Length);

        Debug.Log($"{ArrayNames[index1]},{ArrayNames[index2]},{ArrayNames[index3]},{ArrayNames[index4]},{ArrayNames[index5]},{ArrayNames[index6]},{ArrayNames[index7]},{ArrayNames[index8]},{ArrayNames[index9]}");

        //Creates var for all the names
        string name1 = ArrayNames[index1];
        var name2 = ArrayNames[index2];
        var name3 = ArrayNames[index3];
        var name4 = ArrayNames[index4];
        var name5 = ArrayNames[index5];
        var name6 = ArrayNames[index6];
        var name7 = ArrayNames[index7];
        var name8 = ArrayNames[index8];
        var name9 = ArrayNames[index9];

        //Button for the employees
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
