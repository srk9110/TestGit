using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoManager 
{
    private static InfoManager instance;
    public MissionInfo missionInfo;

    private InfoManager()
    {

    }

    private static InfoManager GetInstance()
    {
        if(InfoManager.instance==null)
        {
            InfoManager.instance = new InfoManager();
            return InfoManager.instance;
        }
        return InfoManager.instance;
    }

    public void Init(MissionInfo newInfo)
    {
        for(int i=0; i<missionInfo.arrGoalcount.Length; i++)
        {
            Debug.Log(this.missionInfo.arrGoalcount[i]);
        }
    }
    
}
