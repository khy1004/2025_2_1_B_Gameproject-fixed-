using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractactableObject : MonoBehaviour
{
    [Header("상호 작용 정보 ")]
    public string objectName = "아이템 ";
    public string interactionText = "[E] 상호 작용";
    public InteractionType interactionType = InteractionType.ltem;

    [Header("하이라이트 설정")]
    public Color highlightColor = Color.yellow;
    public float highlightlntensity = 1.5f;

    public Renderer objectRenderer;
    private Color originalColor;
    private bool isHighlighted = false;

    public enum InteractionType
    {
        ltem,
        Machine,
        Building,
        NPC,
        Cellectible
    }

    public virtual void OnPlayerErter()
    {
        Debug.Log($"[{objectName}) 감지됨");
        HighlightObject();
    }

    public virtual void OnPlayerExit()
    {
        Debug.Log($"[{objectName}) 감지됨");
       RemoveHighlight();
    }
    protected virtual void HighlightObject()
    {
        if (objectRenderer != null && !isHighlighted)
        {
            objectRenderer.material.color = highlightColor;
            objectRenderer.material.SetFloat("_Emission", highlightlntensity);
            isHighlighted = true;
        }
    }

    protected virtual void RemoveHighlight()
    {
        if (objectRenderer != null && !isHighlighted)
        {
            objectRenderer.material.color = originalColor;
            objectRenderer.material.SetFloat("_Emission", 0f);
            isHighlighted = false;

        }
    }

    protected virtual void Collectltem()
    {
      
        {
            Destroy(gameObject);
        }
    }
    protected virtual void OperateMachine()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = Color.green;
        }
    }

    protected virtual void AccessBuilding()
    {
        transform.Rotate(Vector3.up * 90f);

    }
    
    protected virtual void TalkToNPC()
    {
        Debug.Log($"{objectName}와 대화를 시작합니다.");
    }

    public virtual void lnteract()
    {
        switch(interactionType)
        {
            case InteractionType.ltem:
                Collectltem();
                break;
            case InteractionType.Machine:
                OperateMachine();
                break;
            case InteractionType.Building:
                AccessBuilding();
                break;
            case InteractionType.Cellectible:
                Collectltem();
                break;
            case InteractionType.NPC:
                TalkToNPC();
                break;
        }
        
    }

    public string GetinteractionText()
    {
        return interactionText;
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
