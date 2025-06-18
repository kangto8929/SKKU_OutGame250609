using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelSO", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    [Header("�������� ���� �̸�")]
    [SerializeField] private string _name;
    public string Name => _name;

    [Header("�������� ���� �� ���� ����")]
    [SerializeField] private int _startLevel;
    public int StartLevel => _startLevel;

    [SerializeField] private int _endLevel;
    public int EndLevel => _endLevel;

    [Header("���� ����")]
    [SerializeField] private float _healthFactor;
    public float HealthFactor => _healthFactor;

    [SerializeField] private float _damageFactor;
    public float DamageFactor => _damageFactor;

    [Header("���� ����")]
    [SerializeField] private float _spawnInterval;
    public float SpawnInterval => _spawnInterval;

    [SerializeField] private float _spawnRate;
    public float SpawnRate => _spawnRate;
}