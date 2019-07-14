using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public int dps = 50;
    public int moveSpeed = 40;
    private Transform target;
    public GameObject explosionEffectPrefab;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform _target) {
        this.target = _target;
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy") {
            col.GetComponent<Enemy>().Damage(dps);
            GameObject effect = Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
            Destroy(gameObject);
        }
    }
}
