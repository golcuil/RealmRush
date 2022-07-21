using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform target;
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15;
    [SerializeField] ParticleSystem projectileParticles;
    
    void Start()
    {

    }

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void AimWeapon()
    {
        float distanceFromEnemy = Vector3.Distance(transform.position, target.transform.position);
        bool isActive;
        weapon.LookAt(target);

        if(distanceFromEnemy < range)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        Attack(isActive);
        
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }


    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
                
            }
        }

        target = closestTarget;

    }
}
