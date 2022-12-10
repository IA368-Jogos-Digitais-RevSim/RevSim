using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Skin;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshBase;
    [SerializeField] private GameObject _meshActivist;
    [SerializeField] private GameObject _meshCommunicator;
    [SerializeField] private GameObject _meshDoctor;
    [SerializeField] private GameObject _meshNegotiator;
    [SerializeField] private GameObject _meshParliamentary;
    [SerializeField] private GameObject _meshProgrammer;
    [SerializeField] private GameObject _meshWorker;
    [SerializeField] private float _minDistanceToMove = 0.5f;
    [SerializeField] private float _speed = 10;

    [SerializeField] private Classe _classe = Classe.ACTIVIST;
    [SerializeField] private bool _sitting = false;
    
    [SerializeField] public string Description { get; private set; }
    [SerializeField] public float CostMoney { get; private set; }
    [SerializeField] public float PowerGain { get; private set; }

    private bool _isMoving = false;
    private Animator _animator;
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(CharacterAnimatorParameters.SITTING, _sitting);
        UpdateSkin();
    }

    public void GoToTarget(Vector3 target)
    {
        transform.position = target;
    }

    public void GoToChair(Vector3 target)
    {
        transform.position = target;
        _animator.SetBool(CharacterAnimatorParameters.SITTING, true);
    }

    public void UpdateSkin()
    {
        string materialPath = CharacterSettings.GetMaterialPath(_classe);

        _meshBase.material = Resources.Load<Material>(materialPath);
        
        UpdateCharacterMesh(materialPath);
    }

    private void UpdateCharacterMesh(string materialPath)
    {
        _meshActivist.SetActive(false);
        _meshCommunicator.SetActive(false);
        _meshDoctor.SetActive(false);
        _meshNegotiator.SetActive(false);
        _meshParliamentary.SetActive(false);
        _meshProgrammer.SetActive(false);
        _meshWorker.SetActive(false);

        switch (_classe)
        {
            case Classe.ACTIVIST:
                _meshActivist.SetActive(true);
                _meshActivist.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.COMMUNICATOR:
                _meshCommunicator.SetActive(true);
                _meshCommunicator.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.DOCTOR:
                _meshDoctor.SetActive(true);
                _meshDoctor.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.NEGOTIATOR:
                _meshNegotiator.SetActive(true);
                _meshNegotiator.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.PARLIAMENTARY:
                _meshParliamentary.SetActive(true);
                _meshParliamentary.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.PROGRAMMER:
                _meshProgrammer.SetActive(true);
                _meshProgrammer.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
            case Classe.WORKER:
                _meshWorker.SetActive(true);
                _meshWorker.GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>(materialPath);
                break;
        }
    }
}
