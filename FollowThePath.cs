//Follow The Path - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Player Movement 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour 
{
    
    //Location Var:
    public Transform[] waypoints;
    [HideInInspector] //serializes variable without it showing in the inspector (right potruding tab)
    public int waypointIndex = 0;

    //Movement Var: 
    public float moveSpeed = 1f; 
    public bool moveAllowed = false; 

    //Used for initialization 
    private void Start()
    {
        //Declaring Player Position - 
        transform.position = waypoints[waypointIndex].transform.position; 
    }

    // Update is called once per frame
    private void Update()
    {
        //Valid Movement Function - 
        if(moveAllowed){
            Move();
        }    
    }
    
    //Moving Player to Waypoint Code - 
    private void Move()
    {
        if(waypointIndex <= waypoints.Length-1){ //moving point toward specific target 
            //general syntax: Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime); //Time.deltaTime = completion time in seconds since the last time frame 

            if(transform.position == waypoints[waypointIndex].transform.position){
                waypointIndex += 1;
            }
        }
    }
}
