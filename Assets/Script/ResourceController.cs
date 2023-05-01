using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour
{
    public TMP_Text resourceDescription;
    public TMP_Text resourceUpgradeCost;
    public TMP_Text resourceUnlockCost;

    private ResourceConfig _config;

    private int _level = 1;

    public void SetConfig(ResourceConfig config){
        _config = config;

        resourceDescription.text = $"{ _config.name } Lv. { _level }\n+{ GetOutput ().ToString ("0") }";
        resourceUnlockCost.text = $"Unlock Cost\n{ _config.unlockCost }";
        resourceUpgradeCost.text = $"Upgrade Cost\n{ GetUpgradeCost () }";
    }

    public double GetOutput(){
        return _config.output * _level;
    }

    public double GetUpgradeCost(){
        return _config.upgradeCost * _level;
    }

    public double GetUnlockCost(){
        return _config.unlockCost;
    }

}
