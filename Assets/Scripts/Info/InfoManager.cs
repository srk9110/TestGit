using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoManager    //Info들을 관리하는 클래스
{
    private static InfoManager instance;    //싱글톤

    public GameInfo gameInfo;
    public UnityAction<int> OnCompleteMission;

    private InfoManager()
    {

    }

    public static InfoManager GetInstance()
    {
        if (InfoManager.instance == null)
        {
            InfoManager.instance = new InfoManager();
            return InfoManager.instance;
        }
        return InfoManager.instance;
    }

    public void Init(GameInfo gameInfo = null)
    {
        if (gameInfo == null)
        {
            this.gameInfo = new GameInfo();
        }

        else
        {
            this.gameInfo = gameInfo;
        }
    }

    public void DoMission(int id, int count)
    {
        var info = this.gameInfo.missionInfoList.Find(x => x.Id == id);

        var data = DataManager.GetInstance().GetMissionData(id);

        if (info.Count < data.goal)
        {
            info.Count += count;

            if (info.Count >= data.goal)
            {
                if (info.IsComplete == false)
                {
                    info.IsComplete = true;
                    this.OnCompleteMission(info.Id);
                }

            }

            var missionName = string.Format(data.name, data.goal);

            Debug.LogFormat("미션 {0} {1}회 실행", missionName, info.Count);
        }

        else
        {
            Debug.Log("미션이 완료되었습니다.");
        }


    }
}
