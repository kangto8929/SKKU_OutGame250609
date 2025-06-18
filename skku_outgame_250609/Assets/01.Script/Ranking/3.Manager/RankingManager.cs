using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;

public class RankingManager : MonoBehaviourSingleton<RankingManager>
{
    private RankingRepository _repository;
    private List<Ranking> _rankings;
    private Ranking _myRanking;

    protected override void Awake()
    {
        base.Awake();
        Init();

    }

    private void Init()
    {
        _repository = new RankingRepository();

        List<RankingSaveData> saveDatList = _repository.Load();

        _rankings = new List<Ranking>();
        foreach(RankingSaveData saveData in saveDatList)
        {
            Ranking ranking = new Ranking(saveData.Email, saveData.Nickname, saveData.Score);
            _rankings.Add(ranking);

            if(ranking.Email == AccountManager.Instance.CurrentAccount.Email)
            {
                _myRanking = ranking;
            }
        }

        if(_myRanking == null)
        {
            AccountDTO me = AccountManager.Instance.CurrentAccount;
            _myRanking = new Ranking(me.Email, me.Nickname, score: 0);

            _rankings.Add(_myRanking);
        }

        Sort();
        OnDataChanged?.Invoke();
        
    }

    private void Sort()
    {
        _rankings.Sort(comparison: (r1, r2) => r1.Score.CompareTo(r2));

        for(int i = 0; i<_rankings.Count; i++)
        {
            _rankings[i].SetRank(i + 1);
        }
    }
}
