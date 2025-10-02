using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager lnstance;

    [Header("UI 요소들")]
    public GameObject questUI;
    public Text qusetTitleText;
    public Text qusetDescriptionTaxt;
    public Text qusetProgressText;
    public Button completeButton;

    [Header("퀘스트 목록")]
    public QuestData[] availableQuests;

    private QuestData currentQuest;
    private int curretQusetlndex = 0;
    // Start is called before the first frame update
    void UpdateQuestUI()
    {
        if (currentQuest == null) return;

        if (qusetTitleText != null)
        {
            qusetTitleText.text = currentQuest.questTitle;
        }

        if (qusetDescriptionTaxt != null)
        {
            qusetDescriptionTaxt.text = currentQuest.description;
        }

        if (qusetProgressText != null)
        {
            qusetProgressText.text = currentQuest.GetProgressText();
        }

    }

  public void StartQuest(QuestData quest)
  {
        if (quest == null) return;

        currentQuest = quest;
        currentQuest.lnitalize();
        currentQuest.isActive = true;

        Debug.Log("퀘스트 시작: " + qusetTitleText);
        UpdateQuestUI();
        if (questUI != null)
        {
            questUI.SetActive(true);
        }
  }

    void CheckDeliveryProgress()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null) return;

        float distnce = Vector3.Distance(player.position, currentQuest.deliveryPosition);

        if (distnce <= currentQuest.deliveryRedius)
        {
            if(currentQuest.currentProgresss == 0)
            {
                currentQuest.currentProgresss = 1;
            }
        }
        else
        {
            currentQuest.currentProgresss = 0;
        }
    }

    public void AddCollectProgress(string itemTag)
    {
        if (currentQuest == null || !currentQuest.isActive) return;

        if (currentQuest.questType == QuestType.Collect && currentQuest.targetTag == itemTag)
        {
            currentQuest.currentProgresss++;
            Debug.Log("아이템 수집 : " + itemTag);
        }
    }

    public void AddlnteractProgress(string objectTag)
    {
        if (currentQuest == null || !currentQuest.isActive) return;

        if (currentQuest.questType == QuestType.lnterect && currentQuest.targetTag == objectTag)
        {
            currentQuest.currentProgresss++;
            Debug.Log("상호 작용 완료: " + objectTag);
        }
    }



    // Update is called once per frame
    public void CompleteCurrentQuest()
    {
        if (currentQuest == null || !currentQuest.isCompleted) return;

        Debug.Log("퀘스트 완료 ! " + currentQuest.rewardMessage);

        if(completeButton != null)
        {
            completeButton.gameObject.SetActive(false);
        }

        curretQusetlndex++;
        if(curretQusetlndex < availableQuests.Length)
        {
            StartQuest(availableQuests[curretQusetlndex]);
        }
        else
        {
            currentQuest = null;
            if(questUI != null)
            {
                questUI.gameObject.SetActive(false);
            }
        }
    }

    void CheckQuestProgress()
    {
        if(currentQuest.questType == QuestType.Drlivery)
        {
            CheckDeliveryProgress();
        }

        if(currentQuest.IsComplete() && !currentQuest.isCompleted)
        {
            currentQuest.isCompleted = true;

            if(completeButton != null)
            {
                completeButton.gameObject.SetActive(true);
            }
        }
    }

    private void Awake()
    {
        if(lnstance == null)
        {
            lnstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

     void Start()
    {
       if(availableQuests.Length > 0)
        {
            StartQuest(availableQuests[0]);
        }
       if(completeButton != null)
        {
            completeButton.onClick.AddListener(CompleteCurrentQuest);
        }
    }

     void Update()
    {
        if(currentQuest !=null && currentQuest.isActive)
        {
            CheckQuestProgress();
            UpdateQuestUI();
        }
    }


}
