using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]

public class QuestData : MonoBehaviour
{
    [Header("�⺻ ����")]
    public string questTitle = "���ο� ����Ʈ";

    [TextArea(2, 4)]
    public string description = "����Ʈ ������ �Է��ϼ���";
    public Sprite questlcon;

    [Header("����Ʈ ����")]
    public QuestType questType;
    public int targetAmount = 1;

    [Header(" ��� ����Ʈ�� (Delivery)")]
    public Vector3 deliveryPosition;
    public float deliveryRedius = 3f;

    [Header("����/��ȣ�ۿ� ����Ʈ��")]
    public string targetTag = "";

    [Header("����")]
    public int experienceReward = 100;
    public string rewardMessage = "����Ʈ �Ϸ�";

    [Header("����Ʈ ����")]
    public QuestData nextQuest;

    [System.NonSerialized] public int currentProgresss = 0;
    [System.NonSerialized] public bool isActive = false;
    [System.NonSerialized] public bool isCompleted = false;
    // Start is called before the first frame update
    public void lnitalize()
    {
        currentProgresss = 0;
        isActive = false;
        isCompleted = false;
    }

    // Update is called once per frame
    public bool IsComplete()
    {
        switch (questType)
        {
            case QuestType.Drlivery:
                return currentProgresss >= 1;
            case QuestType.Collect:
            case QuestType.lnterect:
                return currentProgresss >= targetAmount;
            default:
                return false;
        }
    }

    public float GetProgressPercentge()
    {
        if (targetAmount <= 0) return 0;
        return Mathf.Clamp01((float)currentProgresss / targetAmount);
    }

    public string GetProgressText()
    {
        switch (questType)
        {
            case QuestType.Drlivery:
                return isCompleted ? "��� �Ϸ�" : "�������� �̵��ϼ���";
            case QuestType.Collect:
            case QuestType.lnterect:
                return $"{currentProgresss} / {targetAmount}";
            default:
                return "";
        }
    }
}
    

    




