using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataStorage
{
    public LevelState State { get; set; }
    public int Index { get; set; }
    public int Stars { get; set; }

    public bool UpdateData(LevelDataStorage levelData)
    {
        bool result = false;
        if (State < levelData.State)
        {
            State = levelData.State;
            result = true;
        }

        if (Stars < levelData.Stars)
        {
            Stars = levelData.Stars;
            result = true;
        }
        return result;
    }

}
public enum LevelState
{
    Closed = 0,
    Open = 1,
    Completed = 2
}
