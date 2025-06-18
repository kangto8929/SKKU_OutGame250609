using UnityEngine;
using System;
using NUnit.Framework.Constraints;

public class Ranking : MonoBehaviour
{
    public int Rank { get; private set; }
    public readonly string Email;
    public readonly string Nickname;
    public int Score { get; private set; }

    public Ranking(string email, string nickname, int score)
    {
        var emailSpecification = new AccountEmailSpecification();
        if (!emailSpecification.IsSatisfiedBy(email))
        {
            throw new Exception(emailSpecification.ErrorMessage);
        }

        var nickNameSpecification = new AccountNicknameSpecification();
        if (string.IsNullOrEmpty(email))
        {
            throw new Exception("�̸����� ������� �� �����ϴ�.");
        }

        if(string.IsNullOrEmpty(nickname))
        {
            throw new Exception("�г����� ������� �� �����ϴ�.");
        }

        Email = email;
        Nickname = nickname;
        Score = score;
    }

    public void SetRank(int rank)
    {
        if(rank <= 0)
        {
            throw new Exception("�ùٸ��� ���� �����Դϴ�.");

        }

        Rank = rank;
    }

    public void AddScore(int score)
    {
        if(score <= 0)
        {
            throw new Exception("�ùٸ��� ���� �����Դϴ�.");
        }

        Score = score;
    }

}
