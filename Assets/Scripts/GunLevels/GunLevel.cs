using Assets.Scripts.Factories;
using System;
using UnityEngine;

public abstract class GunLevel : ScriptableObject, IGunImprover, IGunLevelInfo
{
    [SerializeField] private string _russianDescription;
    [SerializeField] private string _englishDescription;
    [SerializeField] private string _turkishDescription;
    [SerializeField] private GunLevel _nextLevel;

    [field: SerializeField] public int Number { get; private set; }

    [field: SerializeField] public int Price { get; private set; }

    public IGunLevelInfo NextLevel => _nextLevel;

    public string LevelDescription { get; private set; }

    public void SetLang(string lang)
    {
        if (lang == "ru")
        {
            LevelDescription = _russianDescription;
        }
        else if (lang == "en")
        {
            LevelDescription = _englishDescription;
        }
        else if (lang == "tr")
        {
            LevelDescription = _turkishDescription;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public abstract void Improve(IGunInitializer gunInitilizer);
}