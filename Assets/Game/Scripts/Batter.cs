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

    // Start is called before the first frame update
    void Start()
    {
        swingAction.performed += OnSwing;
        swingAction.Enable();
        bat.position = holdPosition.position;
    }

    void OnDestroy()
    {
        swingAction.Disable();
        swingAction.performed -= OnSwing;
    }

    private void OnSwing(CallbackContext c)
    {
        // show bat for 1 second

        StartCoroutine(DoBatAnimation());
    }

    private IEnumerator DoBatAnimation()
    {
        bat.position = batPosition.position;

        yield return new WaitForSeconds(1);

        bat.position = holdPosition.position;
    }
}
