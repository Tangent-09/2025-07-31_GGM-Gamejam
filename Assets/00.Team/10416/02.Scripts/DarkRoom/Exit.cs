using UnityEngine;

public class Exit : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject player;

    private void Awake()
    {
       audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player");

    }
    private void Update()
    {
        audioSource.volume = Mathf.Clamp(1-Vector2.Distance(player.transform.position,transform.position)/10, 0, 1);
    }
}
