using UnityEngine;

[CreateAssetMenu(fileName = "AchievementSO", menuName = "Scriptable Objects/AchievementSO")]
public class AchievementSO : ScriptableObject
{
    [SerializeField]
    private string _id;
    public string ID => _id;

    [SerializeField]
    private string _name;
    public string Name => _name;

    [SerializeField]
    public string _description;
    public string Description => _description;

    [Header("발생 조건")]
    public EAchievementCondition Condition;
    public int GoalValue;
    public ECurrencyType RewardCurrencyType;
    public int RewardAmount;

}
