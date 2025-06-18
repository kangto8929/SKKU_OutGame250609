using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceManager : MonoBehaviour
{
    public static AttendanceManager Instance;

    [SerializeField]
    private List<AttendanceSO> _attendanceSoList;

    private List<Attendance> _attendances;


    public event Action OnDataChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }

    private void Init()
    {
        _attendances = new List<Attendance>(_attendanceSoList.Count);
        DateTime today = DateTime.Today;

        // SO�� ��ȸ�ϸ鼭
        foreach (var atttendanceSo in _attendanceSoList)
        {
            // ���� ������ �̺�Ʈ�� �ƴ϶�� �ǳʶڴ�.
            if (atttendanceSo.StartDate < today)
            {
                continue;
            }

            if (FindById(atttendanceSo.ID) != null)
            {
                throw new Exception("�ߺ��� �⼮üũ �̺�Ʈ�Դϴ�.");
            }

            Attendance attendance = new Attendance(atttendanceSo.ID, atttendanceSo.StartDate, today, 1);
            foreach (var atendanceRewardSO in atttendanceSo.AttendanceRewards)
            {
                attendance.AddReward(new AttendanceReward(atendanceRewardSO.CurrencyType, atendanceRewardSO.Amount, false));
            }

            _attendances.Add(attendance);
        }

        StartCoroutine(Check_Coroutine());
    }

    private Attendance FindById(string id)
    {
        Attendance attendance = _attendances.Find(x => x.ID == id);

        return attendance;
    }

    public AttendanceDTO GetAttendance(string id)
    {
        Attendance attendance = FindById(id);
        if (attendance == null)
        {
            throw new Exception("Attendance not found");
        }

        return attendance.ToDTO();
    }

    public bool TryRewardClaim(string attendanceID, int index)
    {
        Attendance attendance = FindById(attendanceID);
        if (attendance == null)
        {
            return false;
        }

        if (attendance.TryClaim(index))
        {
            AttendanceRewardDTO reward = attendance.GetReward(index);

            return true;

            CurrencyManager.Instance.Add(reward.CurrencyType, reward.Amount);

            OnDataChanged?.Invoke();
        }


        return false;
    }


    private IEnumerator Check_Coroutine()
    {
        var hourTimeWait = new WaitForSecondsRealtime(60 * 60);

        while (true)
        {
            DateTime today = DateTime.Today;

            foreach (Attendance attendance in _attendances)
            {
                // ���� ���� ���Ѷ�!
                attendance.Check(today);

            }

            OnDataChanged?.Invoke();

            yield return hourTimeWait;
        }
    }

}
