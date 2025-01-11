using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using TMPro;
using UnityEngine.UI;

public class SpinnerController : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;

    [SerializeField] private TextMeshProUGUI uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;
    // Start is called before the first frame update
    void Start()
    {
        uiSpinButton.onClick.AddListener(() =>
        {
            uiSpinButton.interactable = false;
            uiSpinButtonText.text = "Spinning";
            pickerWheel.OnSpinStart(() =>
            {
                Debug.Log("Spin Started...");
            });
            pickerWheel.OnSpinEnd(wheelPiece =>
            {
                Debug.Log("Spin end: Label:" + wheelPiece.Label + " ,amount: " + wheelPiece.Amount);
                uiSpinButton.interactable = true;
                uiSpinButtonText.text = "Spin";
            });
;            pickerWheel.Spin();
        });
    }
}
