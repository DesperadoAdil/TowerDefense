using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turret;
    public GameObject buildEffect;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void BuildTurret(GameObject turretPrefab) {
        turret = Instantiate(turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }
}
