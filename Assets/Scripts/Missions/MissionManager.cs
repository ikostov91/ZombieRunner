using Assets.Scripts.Missions;
using Assets.Scripts.Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private List<MissionBase> _missions;

    void Awake()
    {
        this._missions = this.gameObject.GetComponents<MissionBase>().ToList();
    }

    void OnGUI()
    {
        foreach (var mission in this._missions)
        {
            mission.DrawHUD();
        }
    }

    void Update()
    {
        foreach (var mission in this._missions)
        {
            if (mission.IsAchieved())
            {
                mission.Complete();
            }
        }

        if (this._missions.All(x => x.IsCompleted))
        {
            FindObjectOfType<WinHandler>().HandleWin();
        }
    }
}
