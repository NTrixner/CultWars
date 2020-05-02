using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct WonderMapping {

[SerializeField]
    public Button button;

[SerializeField]
    public AbstractWonder wonder;

}

public class Wonders : MonoBehaviour
{
    [SerializeField]
    List<WonderMapping> wonders;

    void OnEnable() {
        foreach(WonderMapping wonder in wonders) {
            if (wonder.button != null && wonder.wonder != null) {
                wonder.button.onClick.AddListener(wonder.wonder.OnWonderButtonClicked);
            }
        }
    }


}
