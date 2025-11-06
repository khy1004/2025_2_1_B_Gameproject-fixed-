using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
[CreateAssetMenu(fileName = "New Achievement" , menuName = "Achievement/AchievementData")]
public class AchievementData : ScriptableObject
{
    public string achivevmentName;
    public string description;
    public AchievementType achievementType;
    public int requiredAmount;
    public int rewardCoins;
    public bool isUnlocked;
    public Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
