using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshBase;
    [SerializeField] private GameObject _meshMan;
    [SerializeField] private GameObject _meshWoman;

    private Animator _animator;
    private bool _isMoving = false;
    private RaycastHit _hit;
    private NavMeshAgent _agent;
    
    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        UpdateSkin();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
                _agent.destination = _hit.point;

        var agenteVelocty = _agent?.velocity;
        var velocity = Mathf.Abs(agenteVelocty?.x?? 0f) + Mathf.Abs(agenteVelocty?.z?? 0f);
        _animator.SetFloat(CharacterAnimatorParameters.SPEED, velocity);
    }

    public void UpdateSkin()
    {
        string materialPath = PlayerSettings.GetPlayerMaterialPath();

        _meshBase.material = Resources.Load<Material>(materialPath);
        if (PlayerSettings.PlayerSkin.genre == Genre.MAN)
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
}
