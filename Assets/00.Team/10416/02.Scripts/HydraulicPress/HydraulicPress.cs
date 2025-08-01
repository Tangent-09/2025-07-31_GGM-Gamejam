using System.Collections;
using UnityEngine;

public class HydraulicPress : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float waitTime = 2;
    [SerializeField] private float maxMoveVal;
    [SerializeField] private float minMoveVal;
    private float moveVal;
    private bool doCorutine = true;

    private void Update()
    {
        if(doCorutine)
        {
            StartCoroutine(movement());
        }
      transform.localScale = new Vector2(transform.localScale.x,Mathf.Lerp(transform.localScale.y,moveVal,Time.deltaTime * speed));
    }

    private IEnumerator movement()
    {
        doCorutine = false;
        moveVal = maxMoveVal;
        yield return new WaitForSeconds(waitTime);
        moveVal = minMoveVal;
        yield return new WaitForSeconds(waitTime);
        doCorutine = true;
    }
}
