using UnityEngine;
using System.Collections;

public class ImpactScript : MonoBehaviour {

    [Header("Impact Despawn Timer")]
    // How long before the impact is destroyed
    public float despawnTimer = 10.0f;

    [Header("Audio")]
    public AudioClip[] impactSounds;
    public AudioSource audioSource;
    public GameObject gameObject;

    private bool hasCollided = false;

    private void Start () {
        // Get a random impact sound from the array
        audioSource.clip = impactSounds[Random.Range(0, impactSounds.Length)];
    }

    private void OnCollisionEnter(Collision collision) {
        if (!hasCollided) {
            // Play the random impact sound
            audioSource.Play();

            // Set the flag to prevent further collisions
            hasCollided = true;

            // Start the despawn timer
            StartCoroutine(DespawnTimer());
        }
    }

    private IEnumerator DespawnTimer() {
        // Wait for the set amount of time
        yield return new WaitForSeconds(despawnTimer);
        // Destroy the impact gameobject
        Destroy(gameObject);
    }
}
