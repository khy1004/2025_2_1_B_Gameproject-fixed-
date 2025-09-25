using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractionSystem : MonoBehaviour
{
    [Header("상호 작용 설정")]
    public float interactionRange = 2.0f;
    public LayerMask interactionLayerMask = 1;
    public KeyCode interactionKey = KeyCode.E;

    [Header("UI 설정")]
    public Text interactionText;
    public GameObject interactionUI;

    private Transform playerTransform;
    private InteractactableObject currentlnteractiable;

    void Start()
    {
        playerTransform = transform;
        HidelnteractionUI();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractables();
        HandlelnteractionInput();
    }
    void HandlelnteractionInput()
    {
        if (currentlnteractiable != null && Input.GetKeyDown(interactionKey))
        {
            currentlnteractiable.lnteract();
        }
        
           

      
    }

    void ShowlnteractionUI(string text)
    {
        if (interactionUI != null)
        {
            interactionUI.SetActive(true);
        }

        if (interactionText != null)
        {
            interactionText.text = text;
        }
    }

    void HidelnteractionUI()
    {
        if(interactionUI != null)
        {
            interactionUI.SetActive(false);
        }
    }

    void CheckForInteractables()
    {
        Vector3 checkPosition = playerTransform.position + playerTransform.forward * (interactionRange * 0.5f);

        Collider[] hitColliders = Physics.OverlapSphere(checkPosition, interactionRange, interactionLayerMask);

        InteractactableObject closestlnteractable = null;
        float closestDistance = float.MaxValue;

        foreach(Collider collider in hitColliders)
        {
            InteractactableObject interactable = collider.GetComponent<InteractactableObject>();
            if (interactable != null)
            {
                float distance = Vector3.Distance(playerTransform.position, collider.transform.position);

                Vector3 directionToObject = (collider.transform.position - playerTransform.position).normalized;
                float angIe = Vector3.Angle(playerTransform.forward, directionToObject);

                if (angIe < 90f && distance < closestDistance)
                {
                    closestDistance = distance;
                    closestlnteractable = interactable;
                }
                
            }

            if (closestlnteractable != currentlnteractiable)
            {
                currentlnteractiable.OnPlayerExit();
            }

            currentlnteractiable = closestlnteractable;

            if (currentlnteractiable != null)
            {
                currentlnteractiable.OnPlayerErter();
                ShowlnteractionUI(currentlnteractiable.GetinteractionText());
            }
           else
            {
                HidelnteractionUI();
            }
        }
    }


    // Start is called before the first frame update
   
}
