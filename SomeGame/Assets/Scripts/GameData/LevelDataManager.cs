using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager
{
    private const string LEVEL_DATA_SAVE_KEY = "level_data_save_key";
    public List<LevelDataStorage> levelDatas = new List<LevelDataStorage>();

    public  LevelDataManager()
    {
        Load();
    }

    public void UpdateLevelData(LevelDataStorage levelData)
    {
        LevelDataStorage foundLevelData = levelDatas.Find(x => x.Index == levelData.Index);

        if (foundLevelData != null) { 
            if (foundLevelData.UpdateData(levelData) == true)
            {
                if (levelData.State == LevelState.Completed && levelData.Index <= levelDatas.Count)
                {
                    levelDatas[levelData.Index].State = LevelState.Open;
                }
                Save();
            }
        }
    }
    private void Save()
    {
        GameDataManager.Save(levelDatas, LEVEL_DATA_SAVE_KEY);
    }
    private void Load()
    {
        GameDataManager.Load<List<LevelDataStorage>>(LEVEL_DATA_SAVE_KEY,
            result => levelDatas = result,
            () =>
            {
                levelDatas = new List<LevelDataStorage>();
                for (int i = 0; i < 10; i++)
                {
                    LevelDataStorage levelData = new LevelDataStorage();
                    levelData.Index = i + 1;
                    if (i == 0)
                    {
                        levelData.State = LevelState.Open;
                    }
                    else
                    {
                        levelData.State = LevelState.Closed;
                    }
                    levelDatas.Add(levelData);
                }
                Save();
            });
    }
}
