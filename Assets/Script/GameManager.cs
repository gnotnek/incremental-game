using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}
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
