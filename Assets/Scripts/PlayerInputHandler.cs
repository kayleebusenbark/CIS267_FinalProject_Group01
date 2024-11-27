using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

//public class PlayerInputHandler : MonoBehaviour
//{
//    public PlayerController playerController;

//    private float doubleClickThreshold = 0.3f;
//    private float holdThreshold = 0.5f;

//    private float lastClickTime = 0f;

//    private bool isHolding = false;

//    private bool isDoubleClick = false;

//    private Coroutine holdCoroutine;

//    private void OnEnable()
//    {
//        InputSystem.EnableDevice(Mouse.current);
//        InputSystem.EnableDevice(Keyboard.current);
//    }
//    public void OnMove(InputAction.CallbackContext context)
//    {
//        playerController.handleMovementInput(context.ReadValue<Vector2>());
//    }
//    public void OnFire(InputAction.CallbackContext context)
//    {
//        if(context.started)
//        {
//            HandleMouseInput(context.control);
//        }

//        if(context.canceled && isHolding)
//        {
//            StopHolding();
//        }
//    }

//    private void HandleMouseInput(InputControl control)
//    {
//        if(control == Mouse.current.leftButton)
//        {
//            HandleLeftClick();
//        }
//        else if(control == Mouse.current.rightButton)
//        {
//            playerController.triggerBlock();
//        }
//    }

//    private void HandleLeftClick()
//    {
//        float currentTime = Time.time;

//        if (currentTime - lastClickTime <= doubleClickThreshold)
//        {
//            isDoubleClick = true;
//            playerController.triggerAttack("attack2LeftMouseClick");
//        }

//        else
//        {
//            isDoubleClick = false;
//            holdCoroutine = StartCoroutine(StartHoldDetection());
//        }

//        lastClickTime = currentTime;

//    }

//    private IEnumerator StartHoldDetection()
//    {
//        isHolding = false;

//        yield return new WaitForSeconds(holdThreshold);

//        if(!isDoubleClick)
//        {
//            isHolding = true;
//            playerController.triggerAttack("attack2LeftMouseClick");
//        }
//    }

//    private void StopHolding()
//    {
//        if(holdCoroutine != null)
//        {
//            StopCoroutine(holdCoroutine);
//        }

//        if(!isHolding && !isDoubleClick)
//        {
//            playerController.triggerAttack("attack1LeftMouseClick");
//        }

//        isHolding=false;
//    }
//}
