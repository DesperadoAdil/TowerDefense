using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour {
    public TurretData laserBeamerData;
    public TurretData missileLauncherData;
    public TurretData standardTurretData;
    public TurretData selectedTurretData;
    public int money = 1000;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider) {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (mapCube.turret == null) {
                        //Create
                        if (money > selectedTurretData.cost) {
                            money -= selectedTurretData.cost;
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        } else {
                            //Tip
                        }
                    } else {
                        //Upgrade
                    }
                }
            }
        }
    }

    public void OnLaserBeamerSelected(bool isOn) {
        if (isOn) {
            selectedTurretData = laserBeamerData;
        }
    }

    public void OnMissileLauncherSelected(bool isOn) {
        if (isOn) {
            selectedTurretData = missileLauncherData;
        }
    }

    public void OnStandardTurretSelected(bool isOn) {
        if (isOn) {
            selectedTurretData = standardTurretData;
        }
    }
}
