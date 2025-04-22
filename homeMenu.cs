using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class homeMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene("homeScene");
        
    }
}