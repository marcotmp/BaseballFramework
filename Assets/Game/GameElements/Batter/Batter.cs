using MarcoTMP.BaseballFramework.Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Batter : MonoBehaviour
{
    [SerializeField] private InputAction swingAction;
    [SerializeField] private Transform bat;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Transform batPosition;

    //
    private BFBatter batter;

    // Start is called before the first frame update
    void Start()
    {
        swingAction.performed += OnSwing;
        swingAction.Enable();
        bat.position = holdPosition.position;
    }

    internal void SetBatterActor(BFBatter batterActor)
    {
    }

    void OnDestroy()
    {
        swingAction.Disable();
        swingAction.performed -= OnSwing;
    }

    private void OnSwing(CallbackContext c)
    {
        // show bat for 1 second
        OnStartSwingAnim();
    }

    private void OnStartSwingAnim()
    {
        StartCoroutine(DoBatAnimation());
    }

    private IEnumerator DoBatAnimation()
    {
        bat.position = batPosition.position;

        yield return new WaitForSeconds(1);

        bat.position = holdPosition.position;
    }
}
