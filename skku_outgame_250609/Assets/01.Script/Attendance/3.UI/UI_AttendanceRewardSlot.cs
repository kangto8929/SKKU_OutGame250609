using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_AttendanceRewardSlot : MonoBehaviour
{
    private string _attendanceID;
    private int _attendanceRewardIndex;

    private AttendanceRewardDTO _dto;

    public Image RewardTypeIcon;
    public TextMeshProUGUI RewardAmountTextUI;
    public Button RewardClaimButton;

    public void Refresh(string attendanceID, int attendanceRewardIndex, AttendanceRewardDTO attendanceReward)
    {
        _attendanceID = attendanceID;
        _attendanceRewardIndex = attendanceRewardIndex;
        _dto = attendanceReward;

        RewardAmountTextUI.text = $"{_dto.Amount:N0}��";
        RewardClaimButton.enabled = _dto.CanClaim;
    }

    // 
    public void TryRewardClaim()
    {
        // �(ID) �⼮�� �� ���� ���� �ּ���~
        AttendanceManager.Instance.TryRewardClaim(_attendanceID, _attendanceRewardIndex);
    }
}