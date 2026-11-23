using System.IO;
using UnityEngine;

public class TheAdamScript
{
    public enum StateMachine
    {
        start = 0,
        execute = 1,
        finish = 2
    }

    public StateMachine currentState = StateMachine.start;

    public void StateCheck()
    {
        switch (currentState)
        {
            case (StateMachine.start):
                Debug.Log("Adam Sees Enum State Machine");
                currentState += 1;
                break;
            case (StateMachine.execute):
                Debug.Log("Adam Anger Activates, Roll to Dodge");
                currentState += 1;
                break;
            case (StateMachine.finish):
                Debug.Log("Adam Realises this State Machine is a joke, 0 marks for me.");
                currentState = 0;
                break;
            default:
                Debug.Log("Adam didn't check this script");
                break;
        }
    }

    public void FileLoad()
    {
        string fileLocation = "C://User/Adam/Crashout/TotallyWorksOnMyPC/WhyWouldntit/best_project420";
        File.ReadAllLines(fileLocation);
        Debug.Log("Totally Works on mine, so totally should work on anyone elses.");
    }

}
