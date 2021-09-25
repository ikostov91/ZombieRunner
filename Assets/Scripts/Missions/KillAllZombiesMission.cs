using Assets.Scripts.EnemyScripts;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Missions
{
    public class KillAllZombiesMission : MissionBase
    {
        private void Update()
        {
            // Debug.Log(string.Format("Zombies left: {0}", FindObjectsOfType<EnemyHealth>().Where(x => !x.IsDead).Count()));
        }

        public override bool IsAchieved()
        {
            var zombiesLeft = FindObjectsOfType<EnemyHealth>().Where(x => !x.IsDead).Count();
            return zombiesLeft == 0;
        }

        public override void Complete()
        {
            // TODO add sound or some other effects on completed
            this._isCompleted = true;
        }

        public override void DrawHUD()
        {
            GUILayout.Label(string.Format("Zombies left: {0}", FindObjectsOfType<EnemyHealth>().Where(x => !x.IsDead).Count()));
        }
    }
}
