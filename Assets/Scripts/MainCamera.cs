using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float moveSpeed = 25.0f;
    public float mouseSpeed = 1000.0f;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float mouse = Input.GetAxisRaw("Mouse ScrollWheel");
        transform.Translate(new Vector3(h*moveSpeed, mouse*mouseSpeed, v*moveSpeed) * Time.deltaTime, Space.World);
    }
}
