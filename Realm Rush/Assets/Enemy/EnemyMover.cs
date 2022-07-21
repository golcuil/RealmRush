using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0,5)]float speed = 1f;
    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();
        GameObject[] wayPoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in wayPoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in path)
        {
            Vector3 startingPos = transform.position;
            Vector3 endingPos = waypoint.transform.position;
            float timeLap = 0;
            transform.LookAt(endingPos);
            while(timeLap < 1)
            {
                timeLap += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startingPos, endingPos, timeLap);
                yield return new WaitForEndOfFrame();

            } 
            
        }

        enemy.StealGold();
        gameObject.SetActive(false);
        
    }
}
