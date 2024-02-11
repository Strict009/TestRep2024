using UnityEngine;

public class QuitGame : MonoBehaviour
{
    
    public void Quit()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If running a built game, quit the application
        Application.Quit();
#endif
    }
}
