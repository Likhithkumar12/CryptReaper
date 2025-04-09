using System.Collections;
using UnityEngine;

public class spawngate : MonoBehaviour
{
    [SerializeField] GameObject robot;
    [SerializeField] float spawntime=5f;
    PlayerHealth Player;
    void Awake()
    {
        Player=FindFirstObjectByType<PlayerHealth>();
    }
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }
    IEnumerator spawnRoutine()
    {
        while(Player)
        {
            Instantiate(robot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawntime);
        }
    }
}
