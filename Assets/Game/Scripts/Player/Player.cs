using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _minDistanceToMove = 0.5f;
    [SerializeField] private float _speed = 10;
    [SerializeField] private SkinnedMeshRenderer _meshBase;
    [SerializeField] private GameObject _meshMan;
    [SerializeField] private GameObject _meshWoman;

    private Animator _animator;
    //private CharacterController _controller;
    private bool _isMoving = false;
    private RaycastHit _hit;
    private Vector3 _target;
    
    void Awake()
    {
        _target = transform.position;
        _animator = GetComponent<Animator>();
        UpdateSkin();
    }

    void Update()
    {
        // Screen click input
        if (Input.GetButtonDown("Fire1"))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
                _target = new Vector3(_hit.point.x, 0, _hit.point.z);

        _animator.SetBool(CharacterAnimatorParameters.IS_MOVING, _isMoving);
    }

    public void UpdateSkin()
    {
        string materialPath = PlayerSettings.GetPlayerMaterialPath();

        _meshBase.material = Resources.Load<Material>(materialPath);
        if (PlayerSettings.PlayerSkin.genre == SkinGenre.MAN)
        {
            _meshMan.SetActive(true);
            _meshWoman.SetActive(false);
            _meshMan.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
        }
        else
        {
            _meshWoman.SetActive(true);
            _meshMan.SetActive(false);
            _meshWoman.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
        }
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
