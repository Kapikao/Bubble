using UnityEngine;
using UnityEngine.SceneManagement;

public class RessetMenager : MonoBehaviour
{
    public int Sceneresetnum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
   public void resetlvl()
    {
        if (Sceneresetnum == 3)
        {
            SceneManager.LoadSceneAsync(6);
        }
        else if (Sceneresetnum == 4)
        {
            SceneManager.LoadSceneAsync(7);
        }
        else if(Sceneresetnum == 6)
        {
            SceneManager.LoadSceneAsync(9);
        }
        
        
    }
}
