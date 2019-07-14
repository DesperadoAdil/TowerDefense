using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public List<GameObject> enemys = new List<GameObject>();
    public float attackGap = 0.5f;
    private float timer = 0f;
    public GameObject bulletPrefab;
    public Transform firePosition;

    // Start is called before the first frame update
    void Start() {
        timer = attackGap;
    }

    // Update is called once per frame
    void Update() {
        if (enemys.Count > 0 && enemys[0] == null)
            for (int i = enemys.Count-1; i >= 0; i--)
                if (enemys[i] == null) enemys.RemoveAt(i);

        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackGap) {
            Attack();
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Enemy") {
            enemys.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Enemy") {
            enemys.Remove(col.gameObject);
        }
    }

    void Attack() {
        //Attack
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
    }
}
