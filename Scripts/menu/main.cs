using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
