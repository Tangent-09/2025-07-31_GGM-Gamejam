using UnityEngine;

public class CourseManager : MonoBehaviour
{
    [SerializeField] private GameObject[] patterns;

    private void Start()
    {
        RandomPattern();
    }

    private void RandomPattern()
    {
        int rand = Random.Range(0, patterns.Length);
        Instantiate(patterns[rand]);
    }
}
