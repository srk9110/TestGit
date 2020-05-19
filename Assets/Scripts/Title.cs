using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Title : MonoBehaviour
{
    public UITitle uiTitle;
    public UnityAction onClickGameStart;


    private void Awake()
    {
        Debug.Log("Title:Awake");
        this.uiTitle = GameObject.FindObjectOfType<UITitle>();
    }

    private void OnEnable()
    {
        Debug.Log("Title:OnEnable");
    }

    private void Start()
    {
        Debug.Log("Title:Start");
    }



    public void Init()
    {
        Debug.Log("Title Init");



        //완료는 했지만 보상을 받지 않은 missionInfo들....
        var missionInfoList = InfoManager.GetInstance().gameInfo.missionInfoList
            .Where(x => x.IsComplete && !x.IsGetReward).ToList();

        foreach (var info in missionInfoList)
        {
            Debug.LogFormat("<color=red>{0} {1} {2}</color>", info.Id, info.IsComplete, info.IsGetReward);
        }

        if (missionInfoList.Count > 0)
        {
            this.uiTitle.ShowNotificationShopIcon();
        }
        else
        {
            this.uiTitle.HideNotificationShopIcon();
        }

        InfoManager.GetInstance().OnCompleteMission = (id) =>
        {
            Debug.LogFormat("미션 {0} 완료 됨!");
        };

        Debug.Log(this.uiTitle);

        this.uiTitle.btnStart.onClick.AddListener(() =>
        {
            //플레이 버튼을 누르면 대리자 호출
            this.onClickGameStart();
        });
    }

}
