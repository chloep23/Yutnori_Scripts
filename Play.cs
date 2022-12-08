//Play - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: Game Loading Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    //Game Scene Loading Function - 
    public void LoadGame() 
    {
        SceneManager.LoadScene(1); //1 = Game Scene
    }
}
