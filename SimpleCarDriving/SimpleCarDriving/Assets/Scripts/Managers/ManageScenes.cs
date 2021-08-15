using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ManageScenes : MonoBehaviour
{
    
    public static void LoadMainMenuScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}