using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateCode : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;
    public int objectCount = 10;
    public float forceAmount = 5f;
    public float spawnDelay = 0.5f;
    public float destroyDelay = 1f;
    public PlayerController playerController;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnAndDestroy());
    }

    IEnumerator SpawnAndDestroy()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject obj = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                int dir = playerController.FacingRight ? 1 : -1;
                rb.AddForce(new Vector2(dir * forceAmount, 0), ForceMode2D.Impulse);
            }

            spawnedObjects.Add(obj);

            yield return new WaitForSeconds(spawnDelay);
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
                yield return new WaitForSeconds(destroyDelay);
            }
        }

        spawnedObjects.Clear();
    }
}
