using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance {
        get{
            if(_instance == null){
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    [Range(0f, 1f)]
    public float AutoCollectPercentage = 0.1f;
    public ResourceConfig[] ResourcesConfigs;

    public Transform ResourcesParent;
    public ResourceController ResourcesPrefab;

    public TMP_Text GoldInfo;
    public TMP_Text AutoCollectInfo;

    private List<ResourceController> _activeResources = new List<ResourceController>();
    private float _collectSound;

    private double _totalGold;
    // Start is called before the first frame update
    void Start() {
        AddAllResources();
    }

    // Update is called once per frame
    void Update() {
        _collectSound += Time.unscaledDeltaTime;

        if(_collectSound >= 1f){
            CollectPerSecond();
            _collectSound = 0f;
        }
    }

    private void AddAllResources() {
        foreach (ResourceConfig config in ResourcesConfigs)
        {
            GameObject obj = Instantiate(ResourcesPrefab.gameObject, ResourcesParent, false);
            ResourceController resource = obj.GetComponent<ResourceController>();
            resource.SetConfig(config);
            _activeResources.Add(resource);
        }
    }

    private void CollectPerSecond(){
        double output = 0;
        foreach(ResourceController resource in _activeResources){
            output += resource.GetOutput();
        }

        output *= AutoCollectPercentage;

        AutoCollectInfo.text = $"Auto Collect: { output.ToString ("F1") } / second"; 

        AddGold(output);
    }

    private void AddGold(double value){
        _totalGold += value;
        GoldInfo.text = $"Gold: { _totalGold.ToString("0")}";
    }
}

//Fungsi System.Serializable adalah agar 
//object bisa di-serialize dan value dapat di-set dari inspector
[System.Serializable]
public struct ResourceConfig{
    public string name;
    public double unlockCost;
    public double upgradeCost;
    public double output;
}
