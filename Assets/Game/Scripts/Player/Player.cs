using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _minDistanceToMove = 0.5f;
    [SerializeField] private float _speed = 10;

    private Animator _animator;
    //private Rigidbody _rigidbody;
    private bool _isMoving = false;
    private RaycastHit _hit;
    private Vector3 _target;
    
    void Awake()
    {
        _target = transform.position;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
                _target = new Vector3(_hit.point.x, 0, _hit.point.z);

        _animator.SetBool(CharacterAnimatorParameters.IS_MOVING, _isMoving);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target) > _minDistanceToMove)
        {
            _isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }
        else
        {
            _isMoving = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == ((int)Layers.OBSTACLE))
        {
            _target = transform.position;
        }
    }
}
