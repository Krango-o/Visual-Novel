using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AlertBox : MonoBehaviour
{
    [SerializeField]
    private Button Confirm;
    [SerializeField]
    private Button Cancel;
    [SerializeField]
    public Text Text;

    private EventSystem eventSystem;
    private GameObject previousButton;

    // Start is called before the first frame update
    void Start()
    {
        Cancel.onClick.AddListener(delegate { GameObject.Destroy(this.gameObject); });
        Confirm.onClick.AddListener(delegate { GameObject.Destroy(this.gameObject); });
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        previousButton = eventSystem.currentSelectedGameObject;
        eventSystem.SetSelectedGameObject(null);
    }

    public void SetConfirmDelegate(UnityAction onClick)
    {
        Confirm.onClick.AddListener(onClick);
    }

    public void SetCancelDelegate(UnityAction onClick)
    {
        Cancel.onClick.AddListener(onClick);
    }

    private void OnDestroy()
    {
        Confirm.onClick.RemoveAllListeners();
        Cancel.onClick.RemoveAllListeners();
        eventSystem.SetSelectedGameObject(previousButton);
    }


    // Update is called once per frame
    void Update()
    {
        if (eventSystem.currentSelectedGameObject == null && (Input.GetAxis("Horizontal") < -0.1f))
        {
            eventSystem.SetSelectedGameObject(Confirm.gameObject);
        }
        else if (eventSystem.currentSelectedGameObject == null && (Input.GetAxis("Horizontal") > 0.1))
        {
            eventSystem.SetSelectedGameObject(Cancel.gameObject);
        }
        if (eventSystem.currentSelectedGameObject != null && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0))
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
}
