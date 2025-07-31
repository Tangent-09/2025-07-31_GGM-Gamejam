using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
   [SerializeField] private Transform[] pos;
    [SerializeField] private float speed;
    private void OnEnable()
    {
        transform.position = pos[0].position;//On Enable, change Laser Position to pos[0]'s position
    }
    private void Update()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, pos[1].position.x, Time.deltaTime * speed), 0);//Towards to EndPos
        if (Mathf.Abs(transform.position.x) > Mathf.Abs(pos[1].position.x)-0.1f)//if Laser is get too closer to EndPos, turn laser setactive false
        {
        gameObject.SetActive(false);
        }
    }
}
