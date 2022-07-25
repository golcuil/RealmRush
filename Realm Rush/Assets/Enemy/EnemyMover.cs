using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
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

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            path.Add(waypoint);

        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
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

        FinishPath();
        
    }
}
