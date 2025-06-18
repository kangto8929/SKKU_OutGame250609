using System;
using System.Collections.Generic;

public class Stage
{
    public int LevelNumber { get; private set; }
    public int SubLevelNumber => _currentLevel.CurrentLevel;

    private StageLevel _currentLevel;

    // ToDO: StageLevelDTO
    public StageLevel CurrentLevel => _currentLevel;


    private float _progressTime;

    public List<StageLevel> Levels { get; private set; } = new List<StageLevel>();


    public Stage(int levelNumber, int subLevelNumber, float progressTime, List<StageLevelSO> levelSoList)
    {
        if (levelNumber < 0)
        {
            throw new Exception("�ùٸ��� ���� �����ѹ� �Դϴ�.");
        }

        if (subLevelNumber < 0)
        {
            throw new Exception("�ùٸ��� ���� ���극�� �ѹ��Դϴ�.");
        }

        if (progressTime < 0)
        {
            throw new Exception("�ùٸ��� ���� ���� �ð��Դϴ�.");
        }

        if (levelSoList == null)
        {
            throw new Exception("�ùٸ��� ���� ���� �������Դϴ�.");
        }


        LevelNumber = levelNumber;
        _progressTime = progressTime;

        foreach (var levelSO in levelSoList)
        {
            // ���� ������ Start ~ End���̷� �����Ѵ�.
            int sub = levelSO.StartLevel;
            if (sub < subLevelNumber)
            {
                sub = levelSO.EndLevel;

                if (subLevelNumber < sub)
                {
                    sub = subLevelNumber;
                }
            }

            AddLevel(new StageLevel(levelSO, sub));
        }

        _currentLevel = Levels[LevelNumber - 1];
    }

    private void AddLevel(StageLevel level)
    {
        if (level == null)
        {
            throw new Exception("������ null�Դϴ�.");
        }

        Levels.Add(level);
    }

    public void Progress(float dt, Action onDateChanged)
    {
        _progressTime += dt;

        if (_currentLevel.TryLevelUp(_progressTime))
        {
            _progressTime = 0;

            if (_currentLevel.IsClear())
            {
                LevelNumber += 1;
                _currentLevel = Levels[LevelNumber - 1];
            }

            onDateChanged?.Invoke();
        }
    }
}