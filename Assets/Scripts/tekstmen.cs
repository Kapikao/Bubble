using UnityEngine;
using UnityEngine.SceneManagement;

public class tekstmen : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;
    public GameObject t6;
    public GameObject t7;
    public int countt = 0;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            countt++;   

        }

        if (countt == 0)
        {
            t1.SetActive(true);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(false);
            t6.SetActive(false);
            t7.SetActive(false);
        }
        else if (countt == 1)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(false);
            t6.SetActive(false);
            t7.SetActive(false);
        }
        else if (countt == 2)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);
            t4.SetActive(false);
            t5.SetActive(false);
            t6.SetActive(false);
            t7.SetActive(false);
        }
        else if (countt == 3)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(true);
            t5.SetActive(false);
            t6.SetActive(false);
            t7.SetActive(false);
        }
        else if (countt == 4)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(true);
            t6.SetActive(false);
            t7.SetActive(false);
        }
        else if (countt == 5)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(false);
            t6.SetActive(true);
            t7.SetActive(false);
        }
        else if (countt == 6)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(false);
            t6.SetActive(false);
            t7.SetActive(true);

        }
        else if (countt == 7)
        {
            SceneManager.LoadSceneAsync(11);
        }
    }
}
