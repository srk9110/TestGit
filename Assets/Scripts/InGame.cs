using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Button[] arrGoalBtns;
    public Text[] arrTextes;
    public Button saveBtn;

    private int[] arrCounts;
    private int[] arrGoal;
    private List<MissionData> missionList;
    private MissionInfo info;

    private void Start()
    {
        this.arrCounts = new int[this.arrGoalBtns.Length];
        this.arrGoal = new int[this.arrGoalBtns.Length];

        for(int i=0; i<this.arrGoal.Length; i++)
        {
            this.arrGoal[i] = missionList[i].goal;
        }


        for(int i=0; i<this.arrGoalBtns.Length; i++)
        {
            int idx = i;
            this.arrGoalBtns[idx].onClick.AddListener(() =>
            {
                arrTextes[idx].text = this.arrCounts[idx].ToString()+" / "+this.arrGoal[idx].ToString();
                this.arrCounts[idx]++;
                this.info.arrGoalcount[idx] = this.arrCounts[idx]-1;
                Debug.Log(this.info.arrGoalcount[idx]);
            });
        }

        this.saveBtn.onClick.AddListener(() =>
        {
            this.SaveData();
        });

    }

    public void Init(List<MissionData> list, MissionInfo info)
    {
        this.info = info;
        this.missionList = list;
    }

    private void SaveData()
    {
        string saveJson = JsonConvert.SerializeObject(this.info);
        Debug.Log(saveJson);

        Debug.Log(Application.persistentDataPath+"/game_info.json");

        File.WriteAllText(Application.persistentDataPath+"/game_info.json", saveJson);
    }
}
