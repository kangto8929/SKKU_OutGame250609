using System;
using UnityEngine.ProBuilder.Shapes;

public class StageLevel
{
    // ��ȹ ������
    public readonly string Name;
    public readonly int StartLevel;             // ���� ����
    public readonly int EndLevel;               // ���� ����
    public float HealthFactor;                  // ü�� ����
    public float DamageFactor;                  // ����� ����
    public float Duration => 60f;          // ���� �ð�
    public readonly float SpawnInterval;        // ���� �ֱ�
    public readonly float SpawnRate;            // ���� Ȯ��

    // ���� ������             
    public int CurrentLevel; // StartLevel ~ EndLevel


    public StageLevel(StageLevelSO so, int currentLevel) : this(so.Name, so.StartLevel, so.EndLevel, so.HealthFactor, so.DamageFactor, so.SpawnInterval, so.SpawnRate, currentLevel)
    {
    }

    public StageLevel(string name, int startLevel, int endLevel, float healthFactor, float damageFactor, float spawnInterval, float spawnRate, int currentLevel)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("�ùٸ��� ���� name�Դϴ�.");
        }

        if (startLevel < 0 || endLevel <= startLevel)
        {
            throw new Exception("���� ������ �ùٸ��� �ʽ��ϴ�.");
        }
        if (endLevel < 0 || endLevel <= startLevel)
        {
            throw new Exception("���� ������ �ùٸ��� �ʽ��ϴ�.");
        }

        if (healthFactor < 1)
        {
            throw new Exception("ü�� ������ �ùٸ��� �ʽ��ϴ�.");
        }
        if (damageFactor < 1)
        {
            throw new Exception("���ݷ� ������ �ùٸ��� �ʽ��ϴ�.");
        }

        if (spawnInterval <= 0)
        {
            throw new Exception("���� �ֱⰡ �ùٸ��� �ʽ��ϴ�.");
        }

        if (spawnRate <= 0 || 100 < spawnRate)
        {
            throw new Exception("���� Ȯ���� �ùٸ��� �ʽ��ϴ�.");
        }

        if (currentLevel < startLevel || endLevel < currentLevel)
        {
            throw new Exception("���� ������ �ùٸ��� �ʽ��ϴ�.");
        }

        Name = name;
        StartLevel = startLevel;
        EndLevel = endLevel;
        HealthFactor = healthFactor;
        DamageFactor = damageFactor;
        SpawnInterval = spawnInterval;
        SpawnRate = spawnRate;
        CurrentLevel = currentLevel;
    }


    public bool TryLevelUp(float progressTime)
    {/*
        if (CurrentLevel >= EndLevel)
        {
            return false;
        }
        */

        if (progressTime >= Duration)
        {
            CurrentLevel += 1;
            return true;
        }

        return false;
    }

    public bool IsClear()
    {
        return CurrentLevel == EndLevel;
    }
}