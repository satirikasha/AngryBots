using UnityEngine;
using System.Collections;



public class Arrow : MonoBehaviour {

    public float damage = 10;

    public float speed = 10;
    public float lifeTime = 0.5f;
    public float dist = 10000;

    public GameObject ArrowHost { get; set; }

    private float spawnTime = 0.0f;
    private Transform tr;

    void OnEnable() {
        tr = transform;
        spawnTime = Time.time;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update() {
        if (Time.time > spawnTime + lifeTime || dist < 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject != ArrowHost) {
            var targetHealth = other.GetComponent<Health>();
            if (targetHealth)
                targetHealth.OnDamage(damage, transform.forward);

            Destroy(gameObject);
        }
    }
}
