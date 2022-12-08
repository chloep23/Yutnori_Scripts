//Game Control - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Game Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{    
    //Object Var: 
    public GameObject originWaypoint; 
    public GameObject CC7;
    public GameObject CC12;
    public GameObject CC22;
    public GameObject CC33;
    public GameObject player1WinText, player2WinText, player1MoveText, player2MoveText;
    public static GameObject player1, player2; 
    public GameObject winPanel;

    //Throw var: 
    public static int stickSideThrown = 0; //value of current move points
    public static int sawiResult ;
    
    //Position Var: 
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int perMovePositionP1 = 0;
    public static int perMovePositionP2 = 0;

    //Route Var: 
    public static bool rightCorner1 = true;
    public static bool rightCorner2 = true;
    public static bool leftCorner1 = true; 
    public static bool leftCorner2 = true; 
    public static bool rightPathP1 = false;
    public static bool rightPathP2 = false;
    public static bool leftPathP1 = false;
    public static bool leftPathP2 = false; 

    //Game End Var: 
    public static bool validWinP1 = false;
    public static bool validWinP2 = false;
    public static bool gameOver = false; 
    
    //Used for initialization 
    void Start()
    {
        //Declaring Static Player Objects - 
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        //Initial Object Status - 
        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;
        
        player1WinText.gameObject.SetActive(false);
        player2WinText.gameObject.SetActive(false);
        
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        
        CC7.gameObject.SetActive(false);
        CC12.gameObject.SetActive(false);
        CC22.gameObject.SetActive(false);
        CC33.gameObject.SetActive(false);
    }

    //Update is called once per frame
    void Update()
    {
        
    //Recalibrating Overlapping Waypoints For Player 1 Code - 
        //Bottom Left Corner From Straight Line : 
        if (player1.GetComponent<FollowThePath>().waypointIndex == 16){
            player1.GetComponent<FollowThePath>().waypointIndex = 38;
            player1StartWaypoint += 22;
        }
        //Bottom Left Corner From Right Diagonal: 
        if (player1.GetComponent<FollowThePath>().waypointIndex == 27){
            player1.GetComponent<FollowThePath>().waypointIndex = 38;
            player1StartWaypoint += 11;
        }
        //Center Piece: 
        if (player1.GetComponent<FollowThePath>().waypointIndex == 24){
            player1.GetComponent<FollowThePath>().waypointIndex = 35;
            player1StartWaypoint += 11;
        }
        
    //Recalibrating Overlapping Waypoints For Player 2 Code  -
        //Bottom Left Corner: 
        if (player2.GetComponent<FollowThePath>().waypointIndex == 16 || player2.GetComponent<FollowThePath>().waypointIndex == 27){
            player2.GetComponent<FollowThePath>().waypointIndex = 38;
            player2StartWaypoint += 22;
        }
        //Bottom Left Corner From Right Diagonal: 
        if (player2.GetComponent<FollowThePath>().waypointIndex == 27){
            player2.GetComponent<FollowThePath>().waypointIndex = 38;
            player2StartWaypoint += 11;
        }
        //Center Piece: 
        if (player2.GetComponent<FollowThePath>().waypointIndex == 24){
            player2.GetComponent<FollowThePath>().waypointIndex = 35;
            player2StartWaypoint += 11;
        }

    //Top Right Corner Route Code - 
        //Stop Movement For Player1: 
        if (rightCorner1 == true && perMovePositionP1 == 6){ //when it reaches top right corner, has two route options 
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            CC7.gameObject.SetActive(true);
            CC22.gameObject.SetActive(true);
        }
        //Stop Movement For Player2: 
        if (rightCorner2 == true && perMovePositionP2 == 6){ //when it reaches top right corner, has two route options 
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            CC7.gameObject.SetActive(true);
            CC22.gameObject.SetActive(true);
        }

        //Straight Line Option For Player1: 
        if (rightCorner1 == false && player1.GetComponent<FollowThePath>().waypointIndex == 6){
            player1.GetComponent<FollowThePath>().moveAllowed = true;
            CC7.gameObject.SetActive(false);
            CC22.gameObject.SetActive(false);
            leftCorner1 = true;
        }

        //Straight Line Option For Player2: 
        if (rightCorner2 == false && player2.GetComponent<FollowThePath>().waypointIndex == 6){
            player2.GetComponent<FollowThePath>().moveAllowed = true;
            CC7.gameObject.SetActive(false);
            CC22.gameObject.SetActive(false);
            leftCorner2 = true;
        }

        //Diagonal Line Option For Player1:  
            //Remaining Moves:
        if (rightPathP1 == true && player1.GetComponent<FollowThePath>().waypointIndex < 21 + stickSideThrown){
           player1.GetComponent<FollowThePath>().moveAllowed = true;
           CC7.gameObject.SetActive(false);
           CC22.gameObject.SetActive(false);
           rightCorner1 = false;
           rightPathP1 = false;
        }
        
        //Diagonal Line Option For Player2:  
            //Remaining Moves:
        if (rightPathP2 == true && player1.GetComponent<FollowThePath>().waypointIndex < 21 + stickSideThrown){
           player2.GetComponent<FollowThePath>().moveAllowed = true;
           CC7.gameObject.SetActive(false);
           CC22.gameObject.SetActive(false);
           rightCorner2 = false;
           rightPathP2 = false;
        }
        
        
    //Top Left Corner Route Code - 
        //Stop Movement For Player1: 
        if (leftCorner1 == true && perMovePositionP1 == 11){
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            CC12.gameObject.SetActive(true);
            CC33.gameObject.SetActive(true);
        }
        //Stop Movement For Player2: 
        if (leftCorner2 == true && perMovePositionP2 == 11){
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            CC12.gameObject.SetActive(true);
            CC33.gameObject.SetActive(true);
        }
        
         //Straight Line Option For Player1: 
        if (leftCorner1 == false && player1.GetComponent<FollowThePath>().waypointIndex == 11){
            player1.GetComponent<FollowThePath>().moveAllowed = true;
            CC12.gameObject.SetActive(false);
            CC33.gameObject.SetActive(false);
        }
        //Straight Line Option For Player2: 
        if (leftCorner2 == false && player2.GetComponent<FollowThePath>().waypointIndex == 11){
            player2.GetComponent<FollowThePath>().moveAllowed = true;
            CC12.gameObject.SetActive(false);
            CC33.gameObject.SetActive(false);
        }
        
        //Diagonal Line Option For Player1:  
            //Remaining Moves:
        if (leftPathP1 == true && player1.GetComponent<FollowThePath>().waypointIndex < 32 + stickSideThrown){
           player1.GetComponent<FollowThePath>().moveAllowed = true;
           CC12.gameObject.SetActive(false);
           CC33.gameObject.SetActive(false);
           leftCorner1 = false;
           leftPathP1 = false;
        }
        
        //Diagonal Line Option For Player2:  
            //Remaining Moves:
        if (leftPathP2 == true && player1.GetComponent<FollowThePath>().waypointIndex < 32 + stickSideThrown){
           player2.GetComponent<FollowThePath>().moveAllowed = true;
           CC12.gameObject.SetActive(false);
           CC33.gameObject.SetActive(false);
           leftCorner2 = false;
           leftPathP2 = false;
        }
        
    //Stop Player 1 Movement Code -      
        if (player1.GetComponent<FollowThePath>().waypointIndex > player1StartWaypoint + stickSideThrown){
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            perMovePositionP1 = player1.GetComponent<FollowThePath>().waypointIndex;
            //Replacement Code - 
            if (perMovePositionP2 == perMovePositionP1){
                player2.transform.position = originWaypoint.transform.position; 
                player2.GetComponent<FollowThePath>().waypointIndex = 1;
                player2StartWaypoint = 0;
                perMovePositionP2 = 0;
                rightCorner2 = true;
                leftCorner2 = true;
                rightPathP2 = false;
                leftPathP2 = false;
                validWinP2 = false;
            }
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex -1;
        }
    
    //Stop Player 2 Movement Code -     
        if (player2.GetComponent<FollowThePath>().waypointIndex > player2StartWaypoint + stickSideThrown){
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            perMovePositionP2 = player2.GetComponent<FollowThePath>().waypointIndex;
            //Replacement Code - 
            if (perMovePositionP1 == perMovePositionP2){
                player1.transform.position = originWaypoint.transform.position; 
                player1.GetComponent<FollowThePath>().waypointIndex = 1;
                player1StartWaypoint = 0;
                perMovePositionP1 = 0;
                rightCorner1 = true;
                leftCorner1 = true;
                rightPathP1 = false;
                leftPathP1 = false;
                validWinP1 = false;
            }
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex -1;
        }
        
    //Prepping For Win Player 1 Code -  
        if (player1.GetComponent<FollowThePath>().waypointIndex == 20 || player1.GetComponent<FollowThePath>().waypointIndex == 31 || player1.GetComponent<FollowThePath>().waypointIndex == 42){
            validWinP1 = true;
        }
        
    //Prepping For Win Player 2 Code -  
        if (player2.GetComponent<FollowThePath>().waypointIndex == 20 || player2.GetComponent<FollowThePath>().waypointIndex == 31 || player2.GetComponent<FollowThePath>().waypointIndex == 42){
            validWinP2 = true;
        }
        
    //Winning Statements For Player 1- 
        if (validWinP1 == true && (player1.GetComponent<FollowThePath>().waypointIndex == 21 || player1.GetComponent<FollowThePath>().waypointIndex == 32 || player1.GetComponent<FollowThePath>().waypointIndex == 43)){
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player1WinText.gameObject.SetActive(true);
            gameOver = true;
            Win();
            Reset();

        }
    //Winning Statements For Player - 
         if (validWinP2 == true && (player2.GetComponent<FollowThePath>().waypointIndex == 21 || player2.GetComponent<FollowThePath>().waypointIndex == 32 || player2.GetComponent<FollowThePath>().waypointIndex == 43)){
            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player2WinText.gameObject.SetActive(true);
            gameOver = true;
            Win();
            Reset();
        }
        
    }
    
    //Win Commands - 
    public void Win(){
        player1MoveText.gameObject.SetActive(false);
        player2MoveText.gameObject.SetActive(false);
        Throw.moText.gameObject.SetActive(false);
        Throw.doText.gameObject.SetActive(false);
        Throw.gaeText.gameObject.SetActive(false);
        Throw.geolText.gameObject.SetActive(false);
        Throw.yutText.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(true);
    }

    //Game Over Reset Commands - 
    public void Reset (){
        gameOver = false;
        player1.transform.position = originWaypoint.transform.position; 
        player2.transform.position = originWaypoint.transform.position; 
        player1.GetComponent<FollowThePath>().waypointIndex = 1;
        player2.GetComponent<FollowThePath>().waypointIndex = 1;
        player1StartWaypoint = 0;
        player2StartWaypoint = 0; 
        perMovePositionP1 = 0;
        perMovePositionP2 = 0;
        stickSideThrown = 0;            
        rightCorner1 = true;
        rightCorner2 = true;
        leftCorner1 = true;
        leftCorner2 = true;
        rightPathP1 = false;
        rightPathP2 = false;
        leftPathP1 = false;
        leftPathP2 = false; 
        validWinP1 = false;
        validWinP2 = false;
        UltimateStick.whosTurn = 1;
    }
    
    //Switch Movement Function - 
    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) {
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            
            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }
    } 
}
    
