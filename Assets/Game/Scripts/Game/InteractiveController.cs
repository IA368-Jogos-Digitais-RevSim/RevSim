using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveController : MonoBehaviour
{
    [SerializeField] private InteractiveObjects[] _interactiveObjects;

    public void EnableOutlines(bool enable)
    {
        foreach (var obj in _interactiveObjects) {
            obj.EnableOutline(enable);
        }
    }
}
