using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static InteractactableObject;

public class Machine : InteractactableObject
{
    // Start is called before the first frame update
    base.Start()
    {
        objectName = "기계";
        interactionText = "[E] 기계 동작";
        interactionType = InteractionType.Building;
    }

    // Update is called once per frame
    protected override void OperateMachine()
    {
        StartCoroutine(DontDestroyOnLoad());
    }

    IEnumerator DontDestroyOnLoad()
    {
        for(int i = 0; i < 50; i++)
        {
            transform.Rotate(new Vector3(0, 1, 0), 30);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.1f);
    }
}
