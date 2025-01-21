using UnityEngine;

public class Lvlcount : MonoBehaviour
{
    public int lvlcount = 0;

    // Update is called once per frame
    void Start()
    {
        
    }

    void Update()
    {
        if ( lvlcount == 0 )
        {
            print ("Jak na razie zero");
        }
    }
}
