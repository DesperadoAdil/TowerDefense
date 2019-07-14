using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour {
    public TurretData laserBeamerData;
    public TurretData missileLauncherData;
    public TurretData standardTurretData;
    private TurretData selectedTurretData;
    private int money = 1000;
    public Text moneyText;
    public Animator moneyAnimator;

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
                    if (selectedTurretData != null && mapCube.turret == null) {
                        //Create
                        if (money >= selectedTurretData.cost) {
                            UpdateMoney(-selectedTurretData.cost);
                            mapCube.BuildTurret(selectedTurretData.turretPrefab);
                        } else {
                            moneyAnimator.SetTrigger("NoMoney");
                        }
                    } else if (mapCube.turret != null) {
                        //Upgrade
                    }
                }
            }
        }
    }

    private void UpdateMoney(int change = 0) {
        money += change;
        moneyText.text = money.ToString() + "B";
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
