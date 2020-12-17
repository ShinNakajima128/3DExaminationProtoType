using System;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class HookShot : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Transform DebugHitPoint;
    [SerializeField] private Transform HookShootTransform;

    private State state;
    private Vector3 hookshotPosition;

    private CharacterController _characterController;
    private PlayerController _PlayerController;

    private float gravity;
    private float hookShootSize;

    //camera
    private Camera FOV;

    private void Start()
    {
        FOV = playerCamera.GetComponent<Camera>();
        _characterController = GetComponent<CharacterController>();
        _PlayerController = GetComponent<PlayerController>();
        gravity = _PlayerController.m_GravityMultiplier;
        HookShootTransform.gameObject.SetActive(false);

    }

    private enum State
    {
        Normal,
        HookShootThrown,
        HookshotFlyingPlayer
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                HookShootStart();
                break;
            case State.HookShootThrown:
                HandleHookShootThrown();
                break;
            case State.HookshotFlyingPlayer:
                HookShotMovement();
                break;
        }
    }


    void HookShootStart()
    {
        if (TestHooking())
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit raycastHit))
            {
                DebugHitPoint.position = raycastHit.point;
                hookshotPosition = raycastHit.point;
                hookShootSize = 0f;
                HookShootTransform.gameObject.SetActive(true);
                HookShootTransform.localScale = Vector3.zero;
                state = State.HookShootThrown;
            }
        }
    }

    void HookShotMovement()
    {
        CameraFOV(100);
        HookShootTransform.LookAt(hookshotPosition);

        _PlayerController.m_GravityMultiplier = 0f;
        Vector3 hookShootDir = (hookshotPosition - transform.position).normalized;

        float MinSpeed = 10f;
        float MaxSpeed = 40f;
        float hookShootSpeed = Mathf.Clamp(Vector3.Distance(transform.position, hookshotPosition), MinSpeed, MaxSpeed);
        float hookShootSpeedMultiplier = 2f;
        _characterController.Move(hookShootDir * hookShootSpeed * hookShootSpeedMultiplier * Time.deltaTime);

        float HookShotDistance = 1f;
        if (Vector3.Distance(transform.position, hookshotPosition) <= HookShotDistance)
        {
            CancelHookShoot();
        }

        if (TestHooking())
        {
            CancelHookShoot();
        }
    }

    bool TestHooking()
    {
        return Input.GetKeyDown(KeyCode.K);
    }

    void HandleHookShootThrown()
    {
        HookShootTransform.LookAt(hookshotPosition);

        float hookThrownSpeed = 30f;
        hookShootSize += hookThrownSpeed * Time.deltaTime;
        HookShootTransform.localScale = new Vector3(1, 1, hookShootSize);

        if (hookShootSize >= Vector3.Distance(transform.position, hookshotPosition))
        {
            state = State.HookshotFlyingPlayer;
        }
    }

    void CancelHookShoot()
    {
        CameraFOV(60);
        state = State.Normal;
        _PlayerController.m_GravityMultiplier = gravity;
        HookShootTransform.gameObject.SetActive(false);

    }

    public void CameraFOV(float FOV_Value)
    {
        FOV.fieldOfView = FOV_Value;
    }

}