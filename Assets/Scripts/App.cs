using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    //앱 목록을 enum타입으로 저장
    private enum eSceneState
    {
        App, Title, InGame
    }

    //eSceneState 타입 변수 sceneState 선언
    private eSceneState sceneState;

    private void Awake()
    {
        //App 오브젝트를 씬 넘어가도 지우지 말어라
        DontDestroyOnLoad(this.gameObject);
        DataManager.GetInstance().Load();
        InfoManager.GetInstance().Init();

        string path = Application.persistentDataPath + "/gameInfo.json";

        if (File.Exists(path))
        {
            string LoadJson = File.ReadAllText(path);
            GameInfo gameInfo = JsonConvert.DeserializeObject<GameInfo>(LoadJson);
            InfoManager.GetInstance().Init(gameInfo);

        }
        else
        {
            InfoManager.GetInstance().Init();

            List<MissionData> missionDataList = DataManager.GetInstance().GetMissionData();
            foreach (var data in missionDataList)
            {
                MissionInfo info = new MissionInfo(data.id, 0);
                InfoManager.GetInstance().gameInfo.missionInfoList.Add(info);

            }
        }
        //Title 씬으로 바꾸기
        this.ChangeScene(eSceneState.Title);

    }

    private void ChangeScene(eSceneState sceneState)
    {
        //콘솔창 메세지 색깔 바꾸기
        Debug.LogFormat("<color=red>{0}</color>", sceneState);

        switch (sceneState)
        {
            case eSceneState.App:
                break;

            case eSceneState.Title:
                {
                    //LoadSceneAsync를 사용하면 Title의 OnEnable다음(start전)에서 넘어감
                    //로딩 중간에 음악이나 애니메이션 실행가능

                    AsyncOperation oper = SceneManager.LoadSceneAsync(sceneState.ToString());
                    oper.completed += (oa) =>
                    {
                        Debug.Log("title로 넘어갑니다~~~~~");
                        Title title = GameObject.FindObjectOfType<Title>();

                        
                        title.Init();

                        title.onClickGameStart = () =>  //게임 스타트가 완료되면
                        {
                            Debug.Log("start");
                            this.ChangeScene(eSceneState.InGame);   //changeScene을 실행시켜
                        };

                    };

                    //sceneLoaded를 쓰면 먼저 넘어가고 Title의 Awake부터 호출
                    //로딩 다할때까지 아무것도 재생 안됨 

                    //SceneManager.sceneLoaded += (Scene argo0, LoadSceneMode arg1) =>
                    //{
                    //    Title title = GameObject.FindObjectOfType<Title>();

                    //    Debug.Log("title로 넘어갑니다~~~~~`");

                    //    title.onClickGameStart = () =>  //게임 스타트가 완료되면
                    //    {
                    //        Debug.Log("start");
                    //        this.ChangeScene(eSceneState.InGame);   //changeScene을 실행시켜
                    //    };
                    //    title.Init();
                    //};
                    //SceneManager.LoadScene(sceneState.ToString());  //Title씬으로 넘어가기
                }
                break;

            case eSceneState.InGame:
                {

                    AsyncOperation oper = SceneManager.LoadSceneAsync(sceneState.ToString());
                    oper.completed += (oa) =>
                    {
                        Debug.Log("InGame로 넘어갑니다~~~~~");

                        InGame inGame = GameObject.FindObjectOfType<InGame>();
                        inGame.Init();

                    };
                }
                break;
        }

    }


}
