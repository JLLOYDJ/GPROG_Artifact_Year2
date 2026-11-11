using Unity.VisualScripting;
using UnityEngine;

public class ID
{
    // Doing underscores for Private variables as it is the naming convention in Microsoft's document.
    private string _name = "NO_NAME";
    private string _description = "NO_DESCRIPTION";
    private uint _id = 0000;

    public string GetName()
    {
        return _name;
    }

    public void SetName(string newName)
    {
        _name = newName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string newDescription)
    {
        _description = newDescription;
    }

    public uint GetUniqueID()
    {
        return _id;
    }

    public void SetUniqueID(uint newID)
    {
        _id = newID;
    }
}
