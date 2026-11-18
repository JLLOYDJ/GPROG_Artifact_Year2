using UnityEngine;
using UnityEngine.UI;

public class UIText : MediatorUI
{
    public void Empty()
    {
        GetComponent<Text>().text = "";
    }

    public void Fill(string desc)
    {
        GetComponent<Text>().text = desc;
    }
}
