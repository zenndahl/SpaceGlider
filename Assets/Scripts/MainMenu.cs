using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void Play(){
       SceneManager.LoadScene("Main");
   }
    public void Quit(){
        Application.Quit();
    }
}
