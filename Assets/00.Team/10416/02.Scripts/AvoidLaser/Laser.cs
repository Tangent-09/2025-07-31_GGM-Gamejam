using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    [SerializeField] private Transform[] pos;
    [SerializeField] private float speed;

    private void OnEnable()
    {
     transform.position = pos[0].position;

    }
    private void Update()
    {
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, pos[1].position.x, Time.deltaTime * speed), 0);
        if(Mathf.Abs(transform.position.x) > Mathf.Abs(pos[1].position.x)-0.1f)
        {
        gameObject.SetActive(false);
        }
    }
}
