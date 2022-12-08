//WP33 - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Waypoint 33 Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP33 : MonoBehaviour
{
    //Object Var: 
     public static GameObject player1, player2;

    //Used for initialization
    void Start()
    {
        //Declaring Players - 
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    //Mouse Clicks Waypoint Code - 
    public void OnMouseDown()
    {
        //Player1 Code - 
        if (UltimateStick.whosTurn == -1){
            player1.GetComponent<FollowThePath>().waypointIndex = 32;
            GameControl.player1StartWaypoint = 31;
            GameControl.leftPathP1 = true;
        }
        //Player2 Code - 
        else if (UltimateStick.whosTurn == 1){
            player2.GetComponent<FollowThePath>().waypointIndex = 32;
            GameControl.player2StartWaypoint = 31;
            GameControl.leftPathP2 = true;
        }
    }
}
