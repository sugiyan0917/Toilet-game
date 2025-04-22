using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TitleMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene("Toilet holder");
        
    }
}