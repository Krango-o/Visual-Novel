using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIUtility : MonoBehaviour
{
    [SerializeField]
    private GameObject AlertBoxPrefab;

    public GameObject CreateAlertBox(string text, Transform parent, UnityAction onConfirm, UnityAction onCancel)
    {
        GameObject newAlert = GameObject.Instantiate(AlertBoxPrefab, parent);
        AlertBox alert = newAlert.GetComponent<AlertBox>();
        alert.Text.text = text;
        alert.SetConfirmDelegate(onConfirm);
        alert.SetCancelDelegate(onCancel);
        return newAlert;
    }
}
