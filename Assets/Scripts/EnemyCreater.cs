using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreater : MonoBehaviour {
    public Wave[] waves;
    public Transform start;
    public float waveGap = 0.5f;
    public static int rest = 0;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(CreateEnemy());
    }

    // Update is called once per frame
    void Update() {}

    IEnumerator CreateEnemy() {
        foreach(Wave wave in waves) {
            for (int i = 0; i < wave.enemyCount; i++) {
                Instantiate(wave.enemyPrefab, start.position, Quaternion.identity);
                rest++;
                if (i != wave.enemyCount-1) yield return new WaitForSeconds(wave.gap);
            }
            while (rest > 0) yield return 0;
            yield return new WaitForSeconds(waveGap);
        }
    }
}
