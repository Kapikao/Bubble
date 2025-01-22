using UnityEngine;
using UnityEngine.SceneManagement;

public class Nextlvlopen : MonoBehaviour
{
    
   public int lvlnumber = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy obiekt to gracz (przyk?ad: Player tag)
        if (other.CompareTag("Player"))
        {
            if (lvlnumber == 2)
            {
                SceneManager.LoadSceneAsync(5);
            }
            else if (lvlnumber == 3)
            {
                SceneManager.LoadSceneAsync(6);
            }
            else if (lvlnumber == 4)
            {
                SceneManager.LoadSceneAsync(7);
            }
            else if (lvlnumber == 5)
            {
                SceneManager.LoadSceneAsync(8);
            }
            else if (lvlnumber == 6)
            {
                SceneManager.LoadSceneAsync(9);
            }
            else if (lvlnumber == 7)
            {
                SceneManager.LoadSceneAsync(10);
            }
            else if (lvlnumber == 8)
            {
                SceneManager.LoadSceneAsync(11);
            }
            else if (lvlnumber == 9)
            {
                SceneManager.LoadSceneAsync(12);
            }
        }
    }
}
