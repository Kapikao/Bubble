using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenuu : MonoBehaviour
{

    

    public void PlayGame()
   {
        SceneManager.LoadSceneAsync(2);
        
        
   }
  public void QuitGame()
    {
        Application.Quit();
        
    }
    public void LVLSc()
    {
         SceneManager.LoadSceneAsync(4);

    }
}

