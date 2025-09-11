using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("타겟 설정")]
    public Transform target;

    [Header("카메라 거리 설정")]
    public float distance = 8.0f;
    public float height = 5.0f;

    [Header("마우스 설정")]
    public float mouseSensivitiy = 2.0f;
    public float minVecticalAngle = -30.0f;
    public float maxVecticalAngle = 60.0f;

    [Header("부드러움 설정")]
    public float positionSmoothTime = 0.2f;
    public float rotationSmoothTime = 0.1f;

    private float horizontalAngle = 0.0f;
    private float verticalAngle = 0.0f;

    private Vector3 currentVelocity;
    private Vector3 currentPossition;
    private Quaternion currentRotation;

    void HandleMouselnput()
    {
        if (Cursor.lockState != CursorLockMode.Locked) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensivitiy;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivitiy;

        horizontalAngle += mouseX;
        verticalAngle -= mouseY;

        verticalAngle = Mathf.Clamp(verticalAngle, minVecticalAngle, maxVecticalAngle);
    }
    // Start is called before the first frame update
    void UpdateCameraSmooth()
    {
        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        Vector3 rotateOffset = rotation * new Vector3(0, height, -distance);
        Vector3 targetPotation = target.position + rotateOffset;

        Vector3 looktarget = target.position + Vector3.up * height;
       Quaternion targetRotation = Quaternion.LookRotation(looktarget - targetPotation);

        currentPossition = Vector3.SmoothDamp(currentPossition, targetPotation, ref currentPossition, positionSmoothTime);

        currentRotation= Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime / rotationSmoothTime);

        transform.position = currentPossition;
        transform.rotation = currentRotation;
    }

    // Update is called once per frame
    void ToggleCursor()
    {
      if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
      else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

   void Start()
    {
       if(target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }
        currentPossition = transform.position;
        currentRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { ToggleCursor(); }
    }

    void LateUpdate()
    {
        if (target == null) return;
        HandleMouselnput();
        UpdateCameraSmooth();
    }
}



