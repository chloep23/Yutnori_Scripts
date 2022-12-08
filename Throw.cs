//Throw - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Throw Button Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    //Button Var: 
    public Button Toss;
    
    //Object Var:
    public GameObject Stick1, Stick2, Stick3, Stick4;
    public static GameObject player1, player2;
    public static GameObject moText, doText, gaeText, geolText, yutText;
    
    //Called before the first frame update
    void Awake() 
    {
        //Declaring U.I. Texts -
        moText = GameObject.Find("moText");
        doText = GameObject.Find("doText");
        gaeText = GameObject.Find("gaeText");
        geolText = GameObject.Find("geolText");
        yutText = GameObject.Find("yutText");
        
        moText.gameObject.SetActive(false);
        doText.gameObject.SetActive(false);
        gaeText.gameObject.SetActive(false);
        geolText.gameObject.SetActive(false);
        yutText.gameObject.SetActive(false);
    }
    
    //Used for initialization 
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        
        Stick1 = GameObject.Find("Stick1");
        Stick2 = GameObject.Find("Stick2");
        Stick3 = GameObject.Find("Stick3");
        Stick4 = GameObject.Find("Stick4");
        
        //Adding Function to Button Click - 
        Toss.onClick.AddListener(TaskOnClick1);
    }
    
    //Button Click Function - 
    void TaskOnClick1()
    {
        //Throws Each Stick Simultaneously - 
        Stick1.GetComponent<Sticks>().OnMouseDown();
        Stick2.GetComponent<Sticks>().OnMouseDown();
        Stick3.GetComponent<Sticks>().OnMouseDown();
        Stick4.GetComponent<UltimateStick>().OnMouseDown();
        
        //Resets Screen - 
        GameControl.sawiResult = 0;
        moText.gameObject.SetActive(false);
        doText.gameObject.SetActive(false);
        gaeText.gameObject.SetActive(false);
        geolText.gameObject.SetActive(false);
        yutText.gameObject.SetActive(false);
    }
}
        