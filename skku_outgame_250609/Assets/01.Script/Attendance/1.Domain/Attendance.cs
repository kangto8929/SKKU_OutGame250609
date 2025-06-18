using System;
using System.Collections.Generic;
using UnityEngine;

public class Attendance
{
    public readonly string ID;
    public readonly DateTime StartDate;                         // �� �⼮(�̺�Ʈ) �������� ������ ���ΰ�?
    public int DayCount { get; private set; }                   // �⼮��
    public DateTime LastAttendanceDate { get; private set; }    // ������ �⼮��

    private List<AttendanceReward> _rewards;

    public Attendance(string id, DateTime startDate, DateTime lastAttendanceDate, int dayCount)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new Exception("ID�� ������� �� �����ϴ�.");
        }

        if (startDate == new DateTime())
        {
            throw new Exception("�⼮ ������ startDate�� �������� �ʾҽ��ϴ�.");
        }

        if (dayCount <= 0)
        {
            throw new Exception("�⼮���� 0���� ���� �� �����ϴ�.");
        }

        if (lastAttendanceDate == new DateTime())
        {
            throw new Exception("�⼮ ������ startDate�� �������� �ʾҽ��ϴ�.");
        }

        if (lastAttendanceDate < startDate)
        {
            throw new Exception("�⼮���� �̺�Ʈ �����Ϻ��� ���� �� �����ϴ�.");
        }

        ID = id;
        StartDate = startDate;
        DayCount = dayCount;
        LastAttendanceDate = lastAttendanceDate;

        _rewards = new List<AttendanceReward>();
    }

    public void Check(DateTime date)
    {
        if (date == new DateTime())
        {
            throw new Exception("�⼮ üũ�ϴ� date�� �������� �ʾѽ��ϴ�.");
        }

        // ToDo: year�� month�� ���Ѵ�.
        if (LastAttendanceDate.Day < date.Day)
        {
            DayCount += 1;
            LastAttendanceDate = date;
        }
    }

    public void AddReward(AttendanceReward reward)
    {
        if (reward == null)
        {
            throw new Exception("�⼮ ������ null�� �� �����ϴ�.");
        }

        _rewards.Add(reward);
    }

    public AttendanceRewardDTO GetReward(int index)
    {
        if (index < 0 || _rewards.Count <= index)
        {
            throw new Exception("��ȿ���� ���� ���� �����Դϴ�.");
        }

        AttendanceReward reward = _rewards[index];
        return new AttendanceRewardDTO(reward.CurrencyType, reward.Amount, reward.Claimed, CanClaim(index));
    }

    public bool CanClaim(int index)
    {
        if (index < 0 || _rewards.Count <= index)
        {
            throw new Exception("��ȿ���� ���� ���� �����Դϴ�.");
        }

        return !_rewards[index].Claimed && DayCount >= index;
    }

    public bool TryClaim(int day)
    {
        if (day < 1 || _rewards.Count < day)
        {
            throw new Exception("�⼮ �ε����� �ùٸ��� �ʽ��ϴ�.");
        }

        if (DayCount < day)
        {
            return false;
        }

        return _rewards[day - 1].TryClaim();
    }

    public AttendanceDTO ToDTO()
    {
        return new AttendanceDTO(ID, StartDate, DayCount, LastAttendanceDate, _rewards);
    }
}