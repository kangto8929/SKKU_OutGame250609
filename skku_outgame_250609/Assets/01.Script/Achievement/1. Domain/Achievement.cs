using System;
using Unity.VisualScripting;
using UnityEngine;

public enum EAchievementCondition
{
    GoldCollect,
    DronKillCount,
    BossKillCount,
    PlayTime,
    Trigger,
}


public class Achievement
{
    // ���� ����: �ڱ⼭����

    // ������
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EAchievementCondition Condition;
    public int GoalValue;
    public ECurrencyType RewardCurrencyType;
    public int RewardAmount;

    // ����
    private int _currentValue;
    public int CurrentValue => _currentValue;

    private bool _rewardClaimed;
    public bool RewardClaimed => _rewardClaimed;


    // ������
    public Achievement(AchievementSO metaData, AchievementSaveData saveData)
    {
        if (string.IsNullOrEmpty(metaData.ID))
        {
            throw new Exception("���� ID�� ������� �� �����ϴ�.");
        }
        if (string.IsNullOrEmpty(metaData.Name))
        {
            throw new Exception("���� �̸��� ������� �� �����ϴ�.");
        }
        if (string.IsNullOrEmpty(metaData.Description))
        {
            throw new Exception("���� ������ ������� �� �����ϴ�.");
        }
        if (metaData.GoalValue <= 0)
        {
            throw new Exception("���� ��ǥ ���� 0���� Ŀ���մϴ�.");
        }
        if (metaData.RewardAmount <= 0)
        {
            throw new Exception("���� ���� ���� 0���� Ŀ���մϴ�.");
        }
        if (saveData.CurrentValue < 0)
        {
            throw new Exception("���� ���� ���� 0���� Ŀ���մϴ�.");
        }

        ID = metaData.ID;
        Name = metaData.Name;
        Description = metaData.Description;
        Condition = metaData.Condition;
        GoalValue = metaData.GoalValue;
        RewardCurrencyType = metaData.RewardCurrencyType;
        RewardAmount = metaData.RewardAmount;

        _currentValue = saveData.CurrentValue;
        _rewardClaimed = saveData.RewardClaimed;
    }

    public void Increase(int value)
    {
        if (value <= 0)
        {
            throw new Exception("���� ���� 0���� Ŀ���մϴ�.");
        }

        _currentValue += value;
    }

    public bool CanClaimReward()
    {
        return _rewardClaimed == false && _currentValue >= GoalValue;
    }

    public bool TryClaimReward()
    {
        if (!CanClaimReward())
        {
            return false;
        }

        _rewardClaimed = true;

        return true;
    }
}