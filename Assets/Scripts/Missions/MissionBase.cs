using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Missions
{
    public abstract class MissionBase : MonoBehaviour
    {
        public abstract bool IsAchieved();
        public abstract void Complete();
        public abstract void DrawHUD();
    }
}
