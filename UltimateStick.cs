//Ultimate Stick - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Ultimate Stick Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateStick : MonoBehaviour
{
    //Stick-Specific Var:
    public Sprite[] stickSides;
    public SpriteRenderer rend;
    public int randomStickSide;
    
    //Turn Var: 
    public static int whosTurn = 1; 
    public bool coroutineAllowed = true; //will not allow the player to toss sticks until turn is over 
    
    //Used for initialization 
    public void Start()
    {
        //Declaring Starting Stick Side - 
        rend = GetComponent<SpriteRenderer>();
        stickSides = Resources.LoadAll<Sprite>("StickSides");
        rend.sprite = stickSides[0];
    }

    //Mouse Touches Stick Code - 
    public void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed){
            StartCoroutine("TossTheSticks");
        }
    }
    
    //Stick Thrown Function - 
    public IEnumerator TossTheSticks()
    {
        coroutineAllowed = false;
        randomStickSide = 0;
        
        //Throwing Effect - 
        for (int i=0; i<=20; i++){
            randomStickSide = Random.Range(0,2); //only from 0-1
            rend.sprite = stickSides[randomStickSide];
            yield return new WaitForSeconds(0.05f);
        }
        if (randomStickSide == 1){
            GameControl.sawiResult += 1;
        }
        
        //Sawi Movements - 
        if (GameControl.sawiResult == 4){
            GameControl.stickSideThrown = 5;
            Throw.moText.gameObject.SetActive(true);
        }
        if (GameControl.sawiResult == 3){
            GameControl.stickSideThrown = 1;
            Throw.doText.gameObject.SetActive(true);
        }
        if (GameControl.sawiResult == 2){
            GameControl.stickSideThrown = 2;
            Throw.gaeText.gameObject.SetActive(true);
        }
        if (GameControl.sawiResult == 1){
            GameControl.stickSideThrown = 3;
             Throw.geolText.gameObject.SetActive(true);
        }
        if (GameControl.sawiResult == 0){
            GameControl.stickSideThrown = 4;
            Throw.yutText.gameObject.SetActive(true); 
        }
        
        //Player Movement Code - 
        if (whosTurn == 1){
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1){
            GameControl.MovePlayer(2);
        }
        
        //Alternating Turns Code - 
        whosTurn *= -1;
        
        coroutineAllowed = true; 
    }
}
    