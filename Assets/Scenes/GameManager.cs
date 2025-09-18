using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ����")]
    public int playerScore = 0;
    public int itemsColledted = 0;

    [Header("UI ����")]
    public Text scoreText;
    public Text itemCountText;
    public Text gameStatusText;

    public static GameManager lnstance;

    // Start is called before the first frame update
    void Awake()
    {
        if(lnstance == null)
        {
            lnstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Collectltem()
    {
        itemsColledted++;
        Debug.Log($"������ ���� ! (�� : {itemsColledted} ��");

    }

    public void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "���� : " + playerScore;
        }

        if (itemCountText != null)
        {
            itemCountText.text = "������ : " + itemCountText + "��";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
