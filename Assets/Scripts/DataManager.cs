using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DataManager
{
    private static DataManager instance;
    private Dictionary<int, MissionData> dicMissonDatas;
    private Dictionary<int, RewardData> dicRewardDatas;

    private DataManager()
    {
        this.dicMissonDatas = new Dictionary<int, MissionData>();
        this.dicRewardDatas = new Dictionary<int, RewardData>();
    }

    public static DataManager GetInstance()
    {
        if (DataManager.instance == null)
        {
            DataManager.instance = new DataManager();
            return DataManager.instance;
        }
        return DataManager.instance;
    }

    public void Load()
    {
        TextAsset missionText = Resources.Load("Data/mission_data") as TextAsset;
        TextAsset rewardText = Resources.Load("Data/reward_data") as TextAsset;

        string missionJson = missionText.text;
        string rewardJson = rewardText.text;

        this.dicMissonDatas = JsonConvert.DeserializeObject<MissionData[]>(missionJson).ToDictionary(x => x.id, x => x);
        this.dicRewardDatas = JsonConvert.DeserializeObject<RewardData[]>(rewardJson).ToDictionary(x => x.id, x => x);

    }

    public List<MissionData> GetMissionData()
    {
        List<MissionData> list = new List<MissionData>();

        foreach (KeyValuePair<int, MissionData> pair in this.dicMissonDatas)
        {
            list.Add(pair.Value);
        }
        return list;
    }

    public MissionData GetMissionData(int id)
    {
        return this.dicMissonDatas[id];
    }

    public RewardData GetRewardDataById(int id)
    {
        return this.dicRewardDatas[id];
    }

}
