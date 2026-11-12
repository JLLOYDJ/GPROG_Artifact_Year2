using UnityEditor.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameInstance;
    public static MoveIndex currentMoveIndex = new MoveIndex();
    void Awake()
    {
        // This section makes the Game Manager into a Singleton as only 1 needs to be working during gameplay.
        if (GameInstance == null)
        {
            GameInstance = this;
            DontDestroyOnLoad(GameInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewMove(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This Function passes through the MoveIndex Result.
    /// </summary>
    /// <param name="IDNumber"></param>
    /// <returns></returns>
    public BaseMove NewMove(uint IDNumber)
    {
        return currentMoveIndex.IDMoveReturn(IDNumber);
    }


}
