﻿using System;
using UnityEngine;
using System.Collections;
using InfimaGames.LowPolyShooterPack;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{

    [Range(5, 100)]
    [Tooltip("After how long time should the bullet prefab be destroyed?")]
    public float destroyAfter;
    [Tooltip("If enabled the bullet destroys on impact")]
    public bool destroyOnImpact = false;
    [Tooltip("Minimum time after impact that the bullet is destroyed")]
    public float minDestroyTime;
    [Tooltip("Maximum time after impact that the bullet is destroyed")]
    public float maxDestroyTime;

    [Header("Impact Effect Prefabs")]

    public Transform[] zombieImpactPrefabs;
    public Transform[] zombieHeadImpactPrefabs;
    public Transform[] bloodImpactPrefabs;
    public Transform[] metalImpactPrefabs;
    public Transform[] dirtImpactPrefabs;
    public Transform[] concreteImpactPrefabs;
    public float damage = 0.15f; // Adjust the damage percentage as nee

    private void Start()
    {
        //Grab the game mode service, we need it to access the player character!
        var gameModeService = ServiceLocator.Current.Get<IGameModeService>();
        //Ignore the main player character's collision. A little hacky, but it should work.
        Physics.IgnoreCollision(gameModeService.GetPlayerCharacter().GetComponent<Collider>(), GetComponent<Collider>());
        StartCoroutine(DestroyAfter());
    }

    //If the bullet collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        float randomDamage = Random.Range(-8f, 8f); // Генеруємо випадкове значення шкоди

        if (collision.transform.tag == "Enemy")
        {
            // Перевірка зіткнення з Zombie
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (zombie != null)
            {
                // Відтворення ефекту колізії з Zombie
                Instantiate(zombieImpactPrefabs[Random.Range(0, zombieImpactPrefabs.Length)],
                    transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

                // Застосування пошкодження до Zombie
                zombie.TakeDamage(damage + randomDamage);
            }

            // Знищення кулі
            Destroy(gameObject);
        }

        if (collision.transform.CompareTag("EnemyHead")) // Зміни "Head" на відповідний тег/шар для голови
        {
            // Перевірка на зіткнення з головою
            Zombie zombie = collision.gameObject.GetComponentInParent<Zombie>();
            if (zombie != null)
            {
                // Відтворення ефекту колізії з головою
                Instantiate(zombieHeadImpactPrefabs[Random.Range(0, zombieHeadImpactPrefabs.Length)],
                    transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

                // Застосування подвоєного пошкодження до Zombie
                zombie.TakeDamage(damage * 3 + randomDamage); // Збільшення пошкодження удвічі
            }

            // Знищення кулі
            Destroy(gameObject);
        }


        if (collision.gameObject.GetComponent<Projectile>() != null)
            return;
        if (!destroyOnImpact)
        {
            StartCoroutine(DestroyTimer());
        }
        //Otherwise, destroy bullet on impact
        else
        {
            Destroy(gameObject);
        }

        //If bullet collides with "Blood" tag
        if (collision.transform.tag == "Blood")
        {
            //Instantiate random impact prefab from array
            Instantiate(bloodImpactPrefabs[Random.Range
                (0, bloodImpactPrefabs.Length)], transform.position,
                Quaternion.LookRotation(collision.contacts[0].normal));
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "Metal" tag
        if (collision.transform.tag == "Metal")
        {
            //Instantiate random impact prefab from array
            Instantiate(metalImpactPrefabs[Random.Range
                (0, bloodImpactPrefabs.Length)], transform.position,
                Quaternion.LookRotation(collision.contacts[0].normal));
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "Dirt" tag
        if (collision.transform.tag == "Dirt")
        {
            //Instantiate random impact prefab from array
            Instantiate(dirtImpactPrefabs[Random.Range
                (0, bloodImpactPrefabs.Length)], transform.position,
                Quaternion.LookRotation(collision.contacts[0].normal));
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "Concrete" tag
        if (collision.transform.tag == "Concrete")
        {
            //Instantiate random impact prefab from array
            Instantiate(concreteImpactPrefabs[Random.Range
                (0, bloodImpactPrefabs.Length)], transform.position,
                Quaternion.LookRotation(collision.contacts[0].normal));
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "Target" tag
        if (collision.transform.tag == "Target")
        {
            //Toggle "isHit" on target object
            collision.transform.gameObject.GetComponent
                <TargetScript>().isHit = true;
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "ExplosiveBarrel" tag
        if (collision.transform.tag == "ExplosiveBarrel")
        {
            //Toggle "explode" on explosive barrel object
            collision.transform.gameObject.GetComponent
                <ExplosiveBarrelScript>().explode = true;
            //Destroy bullet object
            Destroy(gameObject);
        }

        //If bullet collides with "GasTank" tag
        if (collision.transform.tag == "GasTank")
        {
            //Toggle "isHit" on gas tank object
            collision.transform.gameObject.GetComponent
                <GasTankScript>().isHit = true;
            //Destroy bullet object
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyTimer()
    {
        //Wait random time based on min and max values
        yield return new WaitForSeconds
            (Random.Range(minDestroyTime, maxDestroyTime));
        //Destroy bullet object
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        //Wait for set amount of time
        yield return new WaitForSeconds(destroyAfter);
        //Destroy bullet object
        Destroy(gameObject);
    }
}