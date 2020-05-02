using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : HealthEntity
{
    [SerializeField]
    GameObject goodGuyPrefab;

    [SerializeField]
    int minGoodGuySpawn;

    [SerializeField]
    int maxGoodGuySpawn;

    [SerializeField]
    AudioSource deathSource;

    void Update()
    {
        base.UpdateHealthEntity();
    }

    public override void Die()
    {
        deathSource.Play();
        Invoke("SpawnAndDie", deathSource.clip.length * 0.8f);

    }

    void SpawnAndDie()
    {
        float xmin = bodyCollider.bounds.min.x;
        float xmax = bodyCollider.bounds.max.x;
        float ymin = bodyCollider.bounds.min.y;
        float ymax = bodyCollider.bounds.max.y;

        Debug.Log("Cage died");
        Destroy(gameObject);

        int numGoodGuySpawn = Random.Range(minGoodGuySpawn, maxGoodGuySpawn + 1);
        Debug.Log("Spawning " + numGoodGuySpawn + " good guys");
        for (int i = 0; i < numGoodGuySpawn; i++)
        {
            float newx = Random.Range(xmin, xmax);
            float newy = Random.Range(ymin, ymax);
            GameObject goodGuy = Instantiate(goodGuyPrefab);
            goodGuy.transform.position = new Vector3(newx, newy, 0.0f);
        }

    }
}
