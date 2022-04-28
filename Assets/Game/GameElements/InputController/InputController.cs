using MarcoTMP.BaseballFramework.Core;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public InputActionAsset asset;

    private InputAction buttonA;
    private InputAction buttonB;
    private InputAction buttonSelect;
    private InputAction buttonStart;
    private InputAction buttonDPad;

    BFGame game;
    BFInputController controller1;

    public void Start()
    {
        var gameplay = asset.FindActionMap("Gameplay");
        buttonA = gameplay.FindAction("ButtonA");
        buttonB = gameplay.FindAction("ButtonB");
        buttonDPad = gameplay.FindAction("Move");
        asset.Enable();
    }

    private void Update()
    {
        if (controller1 != null)
        {
            controller1.buttonA = buttonA.ReadValue<float>() != 0;
            controller1.buttonB = buttonB.ReadValue<float>() != 0;
            //controller1.buttonStart = buttonStart.ReadValue<float>() != 0;
            //controller1.buttonSelect = buttonSelect.ReadValue<float>() != 0;

            var dPad = buttonDPad.ReadValue<Vector2>();
            controller1.dPadUp = dPad.y > 0;
            controller1.dPadDown = dPad.y < 0;
            controller1.dPadLeft = dPad.x < 0;
            controller1.dPadRight = dPad.x > 0;

            //Debug.Log(JsonUtility.ToJson(controller1));
        }
    }

    internal void ConnectInput(BFInputController player1InputController)
    {
        controller1 = player1InputController;
    }
}
