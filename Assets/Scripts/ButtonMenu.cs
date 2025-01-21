using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public GameObject ACT1;
    public GameObject ACT2;
    public GameObject ACT3;
    public GameObject ACT4;
    public GameObject ACT5;
    public GameObject ACT6;
    public GameObject ACT7;
    public GameObject ACT8;
    public GameObject end;
    public int lvlcount;
    
    void Start()
    {
        lvlcount = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (lvlcount == 1)
        {
            lvl2();
        }
        else if (lvlcount == 2)
        {
            lvl3();
        }
        else if (lvlcount == 3)
        {
            lvl4(); 
        }
        else if (lvlcount == 4)
        {
            lvl5(); 
        }
        else if (lvlcount == 5)
        {
            lvl6();
        }
        else if (lvlcount == 6)
        {
            lvl7();
        }
        else if (lvlcount == 7)
        {
            lvl8();
        }
        else if (lvlcount == 8)
        {
            lvl9();
        }
        else
        {
            nonelvl();
        }
    }

    public void lvl2()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(false);
        ACT4.SetActive(false);
        ACT5.SetActive(false);
        ACT6.SetActive(false);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }
    public void lvl3()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(false);
        ACT5.SetActive(false);
        ACT6.SetActive(false);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }

    public void lvl4()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(false);
        ACT6.SetActive(false);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }

    public void lvl5()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(true);
        ACT6.SetActive(false);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }

    public void lvl6()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(true);
        ACT6.SetActive(true);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }

    public void lvl7()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(true);
        ACT6.SetActive(true);
        ACT7.SetActive(true);
        ACT8.SetActive(false);
        end.SetActive(false);
    }

    public void lvl8()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(true);
        ACT6.SetActive(true);
        ACT7.SetActive(true);
        ACT8.SetActive(true);
        end.SetActive(false);
    }

    public void lvl9()
    {
        ACT2.SetActive(true);
        ACT3.SetActive(true);
        ACT4.SetActive(true);
        ACT5.SetActive(true);
        ACT6.SetActive(true);
        ACT7.SetActive(true);
        ACT8.SetActive(true);
        end.SetActive(true);
    }

    public void nonelvl()
    {
        ACT2.SetActive(false);
        ACT3.SetActive(false);
        ACT4.SetActive(false);
        ACT5.SetActive(false);
        ACT6.SetActive(false);
        ACT7.SetActive(false);
        ACT8.SetActive(false);
        end.SetActive(false);
    }
}

