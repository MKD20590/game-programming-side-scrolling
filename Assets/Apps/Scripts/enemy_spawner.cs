using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField] private float rate = 5f;
    [SerializeField] private float X_minDistance = 7f;
    [SerializeField] private float X_maxDistance = 15f;
    [SerializeField] private GameObject enemy_prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawns()
    {
        Vector3 location = GameObject.Find("Capsule_Player").transform.position;
        //spawns on the right
        if (Random.Range(-2, 2) > 0)
        {
            location.x += Random.Range(X_minDistance, X_maxDistance);
        }
        //spawns on the left
        else
        {
            location.x -= Random.Range(X_minDistance, X_maxDistance);
        }
        GameObject enemy = Instantiate(enemy_prefab,location, Quaternion.identity);
        yield return new WaitForSeconds(rate);
        StartCoroutine(spawns());
    }
}
