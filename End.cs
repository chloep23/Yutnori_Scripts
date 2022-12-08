//End - 
//Name: Chloe Park 
//Submission Date: Monday, December 6
//Purpose: End Scene Loading Function 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    //End Game Function - 
    public void LoadEndScene() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //only in Unity Editor
        #endif
            Application.Quit(); //On Separate Application 
    }
}
