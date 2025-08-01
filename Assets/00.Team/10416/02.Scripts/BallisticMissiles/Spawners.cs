using System.Collections;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject missilePrefeb;
    private GameObject[] missilePool;
    [SerializeField] private int missileCount;
    [SerializeField] private float coolTime;
    private bool canSpawn;

    private void Awake()
    {
        canSpawn = true;
      missilePool = new GameObject[missileCount];
      for (int i = 0; i < missileCount; i++)
     {
      GameObject missile = Instantiate(missilePrefeb);
      missilePool[i] = missile;
      missile.SetActive(false);
     }
    }

    private void Update()
    {
     if(canSpawn)
        {
            StartCoroutine(Spawning());
        }
      
    }

    private void SpawnMissile()
    {
     for(int i = 0; i < missileCount;i++)
     {
         if(!missilePool[i].activeSelf)
        {
         missilePool[i].transform.position = spawners[Random.Range(0, spawners.Length)].position;
         missilePool[i].SetActive(true);
         break;
         }
     }
    }
    
    private IEnumerator Spawning()
    {
     canSpawn = false;
     SpawnMissile();
     yield return new WaitForSeconds(coolTime);
     canSpawn = true;
    }

}
