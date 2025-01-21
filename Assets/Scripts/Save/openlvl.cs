using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openlvl : MonoBehaviour
{
    public void Openmenu()
    {
        SceneManager.LoadSceneAsync(1);

    }


    public void Openlvl1()
    {
        SceneManager.LoadSceneAsync(2);

    }

    public void OpenAct2()
    {
        SceneManager.LoadSceneAsync(5);

    }
    public void OpenAct3()
    {
        SceneManager.LoadSceneAsync(6);

    }

    public void OpenAct4()
    {
        SceneManager.LoadSceneAsync(7);

    }

    public void OpenAct5()
    {
        SceneManager.LoadSceneAsync(8);

    }

    public void OpenAct6()
    {
        SceneManager.LoadSceneAsync(9);

    }

    public void OpenAct7()
    {
        SceneManager.LoadSceneAsync(10);

    }

    public void OpenAct8()
    {
        SceneManager.LoadSceneAsync(11);

    }
    public void OpenAct9()
    {
        SceneManager.LoadSceneAsync(12);

    }
    public void LvUp(int lvlcount)
    {
        lvlcount += 1;
    }

}