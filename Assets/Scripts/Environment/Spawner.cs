using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> projectiles;
    public float fireChance = 0.1f;
    public float power = 1f;
    public Vector3 minPoint;
    public Vector3 maxPoint;


    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(FireLoop());
    }

    private IEnumerator FireLoop()
    {        
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Random.Range(0f, 1f) < fireChance)
            {
                Vector3 spawnPoint = GetRandomVector3Between(minPoint, maxPoint, 0, 0);
                var projectile = Instantiate(projectiles[Random.Range(0, projectiles.Count - 1)], spawnPoint, Quaternion.identity);
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * power);
            }
        }
    }

    private Vector3 GetRandomVector3Between(Vector3 min, Vector3 max)
    {
        return min + Random.Range(0f, 1f) * (max - min);
    }


    private Vector3 GetRandomVector3Between(Vector3 min, Vector3 max, float minPadding, float maxPadding)
    {
        //minpadding as a value between 0 and 1
        float distance = Vector3.Distance(min, max);
        Vector3 point1 = min + minPadding * (max - min);
        Vector3 point2 = max + maxPadding * (min - max);
        return GetRandomVector3Between(point1, point2);
    }
}
