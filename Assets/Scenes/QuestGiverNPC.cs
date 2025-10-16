using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverNPC : InteractableObject
{
    [Header("NPC Quest Settings")]
    public QuestData questToGive;
    public string npcName = "NPC";
    public string questStarMessge = "���ο� ����Ʈ �ֽ��ϴ�.";
    public string noQuestMessage = "����Ʈ�� �����ϴ�.";
    public string QuestAlreadyActiveMessage = "�̹� �������� ����Ʈ�� �ֽ��ϴ�.";

    private QuestManager questManager;

    protected override void Start()
    {
        base.Start();

        questManager = FindAnyObjectByType<QuestManager>();

        if (questManager == null)
        {
            Debug.LogError("QuestManager �� �����ϴ�.");

            interactionText = "[E]" + npcName + "�� ��ȭ�ϱ�";
        }
    }

    public override void Interact()
    {
        base.Interact();
        questManager.StartQuest(questToGive);
    }

    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        
    }
}
