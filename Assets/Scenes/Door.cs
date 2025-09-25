using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractactableObject;

public class Door : InteractactableObject
{

    [Header("�� ����")]
    public bool isOpen = false;
    public Vector3 openPosition;
    public float openSpeed = 2f;

    private Vector3 closdPosition;

    protected override void Start()
    {
        base.start();
        objectName = "��";
        interactionText = "[E] �� ����";
        interactionType = InteractionType.Building;

        closdPosition = transform.position;
        openPosition = closdPosition + Vector3.right * 3f;
    }

    protected override void AccessBuilding()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            interactionText = "[E] �� �ݱ�";
           StartCoroutine(MoveDoor(closdPosition));
        }
        else
        {
            interactionText = "[E] �� ����";
            StartCoroutine(MoveDoor(openPosition));
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, openSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = targetPosition;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
