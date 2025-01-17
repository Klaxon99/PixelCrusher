using System;

namespace Assets.Scripts.Models
{
    public interface IGameMission
    {
        public event Action Succeeded;
    }
}