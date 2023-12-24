using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratsScript : MonoBehaviour
{
    public void RestartGame(){
        SceneManager.LoadScene(0);
    }

    public void EndGame(){
        Application.Quit();
    }
}
