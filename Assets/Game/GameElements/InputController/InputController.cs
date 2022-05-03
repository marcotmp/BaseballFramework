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

    BFInputController gameController;

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
        if (gameController != null)
        {
            gameController.buttonA = buttonA.ReadValue<float>() != 0;
            gameController.buttonB = buttonB.ReadValue<float>() != 0;
            //controller1.buttonStart = buttonStart.ReadValue<float>() != 0;
            //controller1.buttonSelect = buttonSelect.ReadValue<float>() != 0;

            var dPad = buttonDPad.ReadValue<Vector2>();
            gameController.dPadUp = dPad.y > 0;
            gameController.dPadDown = dPad.y < 0;
            gameController.dPadLeft = dPad.x < 0;
            gameController.dPadRight = dPad.x > 0;

        }
    }

    internal void ConnectInput(BFInputController playerInputController)
    {
        gameController = playerInputController;
    }
}
