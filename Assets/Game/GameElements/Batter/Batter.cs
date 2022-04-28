using MarcoTMP.BaseballFramework.Core;
using System.Collections;
using UnityEngine;


public class Batter : MonoBehaviour
{
    [SerializeField] private Transform bat;
    [SerializeField] private Transform holdPosition;
    [SerializeField] private Transform batPosition;

    //
    private BFBatter batter;

    // Start is called before the first frame update
    void Start()
    {
        bat.position = holdPosition.position;
    }

    internal void SetBatterActor(BFBatter batterActor)
    {
        batter = batterActor;
        batter.startSwingAnimation = OnStartSwingAnim;
    }

    void OnDestroy()
    {

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
        batter.SwingAnimationComplete();
    }
}
