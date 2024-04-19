using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputActionReference hmdPositionInputAction;
    [SerializeField] private InputActionAsset ActionAsset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("DebugInputSystem", 5);
    }

    private void DebugInputSystem()
    {
        Vector3 hmdPosition = hmdPositionInputAction.action.ReadValue<Vector3>();
        Debug.Log(hmdPosition);
    }

    private void OnEnable()
    {
        if (ActionAsset != null)
        {
            ActionAsset.Enable();
        }
    }

}
