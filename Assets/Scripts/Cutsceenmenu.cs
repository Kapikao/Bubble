using UnityEngine.SceneManagement;
using UnityEngine;



public class Cutsceenmenu : MonoBehaviour
{
    public int count = 0;
    public GameObject sc1;
    public GameObject sc2;
    public GameObject sc3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count++;
        }

        if (count == 0)
        {
            sc1.SetActive(true);
            sc2.SetActive(false);
            sc3.SetActive(false);
        }
        else if (count == 1)
        {
            sc1.SetActive(false);
            sc2.SetActive(true);
            sc3.SetActive(false);
        }
        else if (count == 2)
        {
            sc1.SetActive(false);
            sc2.SetActive(false);
            sc3.SetActive(true);
        }
        else if (count == 3)
        {
            SceneManager.LoadSceneAsync(8);
        }
    }
}
