using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenege : MonoBehaviour
{
    // public static SceneMenege sceneMenege;
    // private void Awake() 
    // {
    //     if(sceneMenege !=null)    
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         sceneMenege = this;
    //     }
    //     DontDestroyOnLoad(gameObject);
    // }

    // private void Start() 
    // {
    //      SceneManager.LoadScene(1);    
    // }

    public static void LoadNextScene() 
    {
        SceneManager.LoadScene(0);
    }
}
