using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.BreakAway.Weapons;
using ExpPlus.BreakAway.Health;

public class PickupController : MonoBehaviour
{

    [Header("References")]
    public Transform target;
    private Rigidbody2D rigidBody;

    private enum PickupType {Essence, Health}
    [Header("Config")]
    [SerializeField]
    private PickupType pickupType = default;
    [SerializeField]
    private HealthVariable healthVariable = default;
    [SerializeField]
    private ElementAmmo elementAmmo = default;
    [SerializeField]
    private int value = 10;
    [SerializeField]
    private float baseSpeed = 1f;
    [SerializeField]
    private float pickupDistance = 0.5f;
    [SerializeField]
    private AudioClip pickupAudioClip = default;

    private void Start() {

        rigidBody = GetComponent<Rigidbody2D>();

        if (target == null)
            target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToTarget > pickupDistance) {

            
            //transform.Translate(transform.up * (baseSpeed * distanceToTarget) * Time.deltaTime);

            UpdateRotation();
        } else {


            if(pickupType == PickupType.Essence) {

                elementAmmo.ammo += value;
            } else {

                healthVariable.health += value;
            }

            if (pickupAudioClip) {

                GameObject audioSourceGameObject = new GameObject(gameObject.name + "_pickup_audio");
                AudioSource audioSource = audioSourceGameObject.AddComponent<AudioSource>();
                audioSource.PlayOneShot(pickupAudioClip);
            }

            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        rigidBody.AddForce(transform.up * (baseSpeed * distanceToTarget));
    }

    private void UpdateRotation() {

        Vector3 direction = target.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
