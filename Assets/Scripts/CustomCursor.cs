using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D myCursor;

    void Start()
    {
        Vector2 hotSpot = new Vector2(myCursor.width / 4, myCursor.height / 4);
        Cursor.SetCursor(myCursor, hotSpot, CursorMode.ForceSoftware);
    }
}