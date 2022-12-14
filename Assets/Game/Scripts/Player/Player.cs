using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshBase;
    [SerializeField] private GameObject _meshMan;
    [SerializeField] private GameObject _meshWoman;

    private Animator _animator;
    private RaycastHit _hit;
    private NavMeshAgent _agent;
    private AudioSource _audioSource;
    private bool walking = false;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        UpdateSkin();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit, 100))
            {
                _agent.destination = _hit.point;
            }
        }

        var agenteVelocty = _agent?.velocity;
        var velocity = Mathf.Abs(agenteVelocty?.x?? 0f) + Mathf.Abs(agenteVelocty?.z?? 0f);
        _animator.SetFloat(CharacterAnimatorParameters.SPEED, velocity);

        UpdateAudio((int) velocity);
    }

    //audio (LeoP)
    private void UpdateAudio(int velox)
    {
        if (velox > 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        if (!_audioSource.isPlaying && walking)
        {
            _audioSource.Play();
        }
        else if (_audioSource.isPlaying && !walking)
        {
            _audioSource.Stop();
        }
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
