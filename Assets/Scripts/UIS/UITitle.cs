using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    public ButtonMenu[] arrBtnMenus;
    public Sprite[] arrIcons;

    public GameObject notiShopIconGo;
    public bool showNotiShopIcon;   //true 일 경우 n 아이콘을 보여준다.

    public GameObject notiMisstionGo;
    public bool showNotiMisstionIcon;   //true 일 경우 ! 아이콘을 보여준다.

    public int mailCount;   //0보다 커야 보여줌
    public UIBinder_Notification uiBinderNotiMessege;

    public Button addFriendBtn;
    public Button faceBookBtn;
    public Button btnStart;

    public GameObject heartBtnGo;
    public GameObject goldBtnGo;
    public GameObject jemBtnGo;

    public UIBinder_SoulGem uiBinderHeart;
    public UIBinder_Coin uiBinderGold;
    public UIBinder_Gem uiBinderGem;

    private MissionInfo info;

    public enum eMenuTypes
    { Items, Shop, Messages, Mission, Ranking, Settings }

    void Start()
    {


        //Budget 하트충전 버튼
        this.uiBinderHeart.addBtn.onClick.AddListener(() =>
        {
            Debug.Log("소울잼 충전");
        });

        //Budget 골드충전 버튼
        this.uiBinderGold.addBtn.onClick.AddListener(() =>
        {
            Debug.Log("코인 충전");
        });

        //Budget 잼충전 버튼
        this.uiBinderGem.addBtn.onClick.AddListener(() =>
        {
            Debug.Log("잼 충전");
        });




        //메세지 알림 on/off
        this.uiBinderNotiMessege.Init(this.mailCount);


        //메뉴 버튼 세팅
        for (int i = 0; i < this.arrBtnMenus.Length; i++)
        {
            var btnName = ((eMenuTypes)i).ToString();
            var btnMenu = this.arrBtnMenus[i];
            btnMenu.Init(this.arrIcons[i], btnName);
        }

        //메뉴 버튼 액션
        for (int i = 0; i < this.arrBtnMenus.Length; i++)
        {
            int index = i;

            var btnMenu = this.arrBtnMenus[i];
            btnMenu.btn.onClick.AddListener(() =>
            {
                Debug.LogFormat("idx: {0}, type: {1}", index, (eMenuTypes)index);

            });
        }

        //친구추가 버튼
        this.addFriendBtn.onClick.AddListener(() =>
        {
            Debug.Log("친구 추가");
        });

        //페이스북 버튼
        this.faceBookBtn.onClick.AddListener(() =>
        {
            Debug.Log("페이스북 연결");
        });



        //DataManager.GetInstance().Load();

        //if(File.Exists(Application.persistentDataPath+"/game_info.json"))
        //{
        //    string loadJson = File.ReadAllText(Application.persistentDataPath+"/game_info.json");
        //    this.info = JsonConvert.DeserializeObject<MissionInfo>(loadJson);
        //}
        //else
        //{           
        //    this.info = new MissionInfo();
        //}

        //List<MissionData> missionList = DataManager.GetInstance().GetMissionData();

        ////가져온 값 출력
        //foreach(var data in missionList)
        //{
        //    RewardData rewardData = DataManager.GetInstance().GetRewardDataById(data.reward_id);
        //    string name = string.Format(data.name, data.goal);
        //    Debug.LogFormat("id: {0},\tname: {1}\tgoal: {2:N0}\t보상타입: {3}\t보상 양: {4}"
        //        ,data.id,name,data.goal,rewardData.name,data.reward_amount);
        //}


        ////게임실행 버튼
        //this.playBtn.onClick.AddListener(() =>
        //{
        //    SceneManager.sceneLoaded += (Scene arg0, LoadSceneMode arg1) =>
        //    {
        //        InGame inGame = GameObject.FindObjectOfType<InGame>();
        //        inGame.Init(missionList,this.info);
        //    };

        //    SceneManager.LoadScene("InGame");
        //});

        //버튼 배열 다르게 가져오는 방법
        //this.btnMenu.OnClick = (idx) =>
        //{

        //};


    }

    public void ShowNotificationShopIcon()
    {
        //상점 알림 on/off
        this.notiMisstionGo.SetActive(true);

    }
    public void HideNotificationShopIcon()
    {
        //상점 알림 on/off
        this.notiMisstionGo.SetActive(false);

    }



}
