using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Transform[] positions;
    private int index = 0;
    public float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start() {
        positions = Waypoints.positions;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        if (index >= positions.Length) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * moveSpeed, Space.World);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.1) index++;
        if (index >= positions.Length) onDestination();
    }

    private void OnDestroy() {
        EnemyCreater.rest--;
    }

    private void onDestination() {
        Destroy(gameObject);
    }

    public void Damage(int damage) {
        //
    }
}
