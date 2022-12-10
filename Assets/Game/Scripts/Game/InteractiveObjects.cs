using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class InteractiveObjects : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private InteractiveController _interactiveController;

    [Header("Immediate action")]
    [SerializeField] private UnityEvent _onImmediateAction;

    [Header("Wait time for action")]
    [SerializeField] private float _waitTime = 0.5f;
    [SerializeField] private UnityEvent _onActionAfterTime;

    private Outline _outline;
    private bool _mouseEnter = false;
    private bool _waiting = false;

    void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    void Update()
    {
        if (_mouseEnter) {
            if (Input.GetMouseButtonDown(0) && _outline.enabled) {
                _mouseEnter = false;
                _interactiveController.EnableOutlines(false);
                _onImmediateAction.Invoke();
                if (!_waiting)
                    StartCoroutine(WaitTimeAction());
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

    public void EnableOutline(bool enable)
    {
        _outline.enabled = enable;
    }

    private IEnumerator WaitTimeAction()
    {
        _waiting = true;
        yield return new WaitForSeconds(_waitTime);
        _onActionAfterTime.Invoke();
        _waiting = false;
    }
}
