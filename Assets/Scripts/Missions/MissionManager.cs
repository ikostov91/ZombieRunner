using Assets.Scripts.Missions;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public MissionBase[] _missions;

    void Awake()
    {
        this._missions = GetComponents<MissionBase>();
    }

    void OnGUI()
    {
        foreach (var mission in this._missions)
        {
            mission.DrawHUD();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var mission in this._missions)
        {
            if (mission.IsAchieved())
            {
                mission.Complete();
                Destroy(mission);
            }
        }
    }
}
