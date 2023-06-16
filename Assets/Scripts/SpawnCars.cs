using System.Collections;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField]
    private GameObject[] carsPrefab;
    [SerializeField]
    private float spawnInterval = 2f;
    [SerializeField]
    private float distancePos = 1.13f;
    [SerializeField]
    private FloatVariableSO speedCar;
    
    private void Start()
    {
        speedCar.onMaxValue.AddListener(StartSpawn);
    }
    private void StartSpawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int spawnIndex = Random.Range(-2, 3);
            Vector3 posSpawn = (transform.position + Vector3.right * (spawnIndex * distancePos));
            Instantiate(carsPrefab[Random.Range(0, carsPrefab.Length)], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
