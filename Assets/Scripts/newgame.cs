using UnityEngine;
using UnityEngine.SceneManagement;

public class newgame : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(1);

    }
}
