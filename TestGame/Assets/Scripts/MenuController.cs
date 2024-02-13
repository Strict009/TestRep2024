using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public string sceneToLoad;

    
    public void LoadScene()
    {
        
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name is not specified!");
        }
    }
}
