using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
      private Collider spawnArea;
      public GameObject[] fruitPrefabs;
      public float minxspawnDelay = 0.25f;
      public float maxSpawndelay = 1f;


      public float minAngle = -15f;
      public float maxAngle = 15f;

      public float minforce = 18f;
      public float maxforce = 22f;

      public float maxLifetime = 5f;

      private void Awake()
      {
            spawnArea = GetComponent<Collider>();
      }

      void OnEnable()
      {
          StartCoroutine(spawn());
      }

      private void OnDisable()
      {
            StopAllCoroutines();
      }

      IEnumerator spawn()
      {

            yield return new WaitForSeconds(2f);
            while (enabled)
            {
                  GameObject prefab= fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
                  Vector3 position = new Vector3();
                  position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
                  position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
                  position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

                  Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

                  GameObject fruit = Instantiate(prefab, position, rotation);
                  
                  Destroy(fruit,maxLifetime);


                  float force = Random.Range(minforce, maxforce);
                  
                  fruit.GetComponent<Rigidbody>().AddForce(fruit.transform.up*force,ForceMode.Impulse);
                  yield return new WaitForSeconds(Random.Range(minxspawnDelay, maxSpawndelay));
            }
      }
}
