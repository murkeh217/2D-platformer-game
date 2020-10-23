using System;

[Serializable]
public class LevelData
{
public int level;

    public LevelData(LobbyController level)
    {
        this.level = LobbyController.currentSceneIndex;
    }
    
}