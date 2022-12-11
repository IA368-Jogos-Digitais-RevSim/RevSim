using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] float _money = 100;
    [SerializeField] float _politicalPower = 0;

    public float Money
    {
        get { return _money; }
        set { _money = value; }
    }

    public float PoliticalPower
    {
        get { return _politicalPower; }
        set { _politicalPower = value; }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void AddMoney(float money)
    {
        _money += money;
    }

    public void AddPoliticalPower(float power)
    {
        _politicalPower += power;
    }
}