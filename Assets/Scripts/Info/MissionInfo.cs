using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInfo
{

    public int Id { get; private set; }          //미션 종류
    public int Count { get; set; }     //미션을 한 횟수
    public bool IsComplete { get; set; }

    public bool IsGetReward { get; set; }

    public MissionInfo(int id, int count)
    {
        this.Id = id;
        this.Count = count;
    }
}
