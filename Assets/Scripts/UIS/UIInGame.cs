using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public UIBinder_Mission[] arrUiBinderMission;
    public Button btnSave;
    public void Init()
    {


        List<MissionData> missionDatasList = DataManager.GetInstance().GetMissionData();
        List<MissionInfo> missionInfoList = InfoManager.GetInstance().gameInfo.missionInfoList;

        for (int i = 0; i < arrUiBinderMission.Length; i++)
        {
            UIBinder_Mission uiBinderMission = this.arrUiBinderMission[i];
            MissionData data = missionDatasList[i];

            MissionInfo info = missionInfoList[i];
            string btnName = string.Format(data.name, data.goal);
            uiBinderMission.Init(data.id, btnName, data.goal, info.Count);

        }
    }

    public void UpdateUI()
    {
        List<MissionInfo> missionInfoList = InfoManager.GetInstance().gameInfo.missionInfoList;

        for (int i = 0; i < arrUiBinderMission.Length; i++)
        {
            UIBinder_Mission uiBinderMission = this.arrUiBinderMission[i];
            MissionInfo info = missionInfoList[i];
            uiBinderMission.UpdateUI(info.Count);

        }
    }
}
