using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    [Header("Immediate action")]
    [SerializeField] private GameObject[] _activate;
    [SerializeField] private GameObject[] _disable;

    [Header("Wait time for action")]
    [SerializeField] private float _waitTime = 0.5f;
    [SerializeField] private GameObject[] _activateAfterTime;
    [SerializeField] private GameObject[] _disableAfterTime;

    private bool _mouseEnter = false;
    private bool _waiting = false;

    void Update()
    {
        if (_mouseEnter) {
            if (Input.GetMouseButtonDown(0)) {
                Action(_activate, _disable);
                if (!_waiting)
                    StartCoroutine(WaitTimeAction(_activateAfterTime, _disableAfterTime));
            }
        }
    }

    void OnMouseEnter()
    {
        _mouseEnter = true;
    }

    void OnMouseExit()
    {
        _mouseEnter = false;
    }

    private void Action(GameObject[] activateObjects, GameObject[] disableObjects)
    {
        foreach (GameObject obj in activateObjects) {
            obj.SetActive(true);
        }
        foreach (GameObject obj in disableObjects) {
            obj.SetActive(false);
        }
    }

    private IEnumerator WaitTimeAction(GameObject[] activateAfterTimeObjects, GameObject[] disableAfterTimeObjects)
    {
        _waiting = true;
        yield return new WaitForSeconds(_waitTime);
        Action(activateAfterTimeObjects, disableAfterTimeObjects);
        _waiting = false;
    }
}
