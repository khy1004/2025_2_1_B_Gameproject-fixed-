using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSlot : MonoBehaviour
{
    [Header("Ul References")]
    public Image iconlmage;
    public Text nameText;
    public Text desscriptionText;
    public Text progressText;
    public Slider progressSlider;

    public void SetAchievement(AchievementData achievement , float progress)
    {
        if (nameText != null)
            nameText.text = achievement.achivevmentName;
       
        if (desscriptionText != null)
            desscriptionText.text = achievement.description;
       
        if (iconlmage != null && achievement.icon != null)
            iconlmage.sprite = achievement.icon;

        if (progressSlider != null)
            progressSlider.value = achievement.isUnlocked ? 1f : progress;

        if (progressText != null)
        {
            if (achievement.isUnlocked)
            {
                progressText.text = "¿Ï·á!";

            }
            else
            {
                int current = Mathf.FloorToInt(progress * achievement.requiredAmount);
                progressText.text = current + "/" + achievement.requiredAmount;
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
