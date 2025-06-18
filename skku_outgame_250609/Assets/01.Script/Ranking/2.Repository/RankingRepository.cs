using System.Collections.Generic;

public class RankingRepository
{
    public List<RankingSaveData> Load()
    {
        // �����Ͱ� ���� ������ ..
        // ���� �ܰ迡�� �����Ͱ� �ʿ��ϴٸ�.. Mocking ����� ����.
        // PlayerPrefs��� '��¥ ������ ��ȯ'
        // ���ؿ� : "GTP�� ��ŷ������ �� ������ش�! 100�� ������"
        return new List<RankingSaveData>()
        {
            new RankingSaveData(1813, "test1@test.com", "��ö���䳢65"),
            new RankingSaveData(2721, "test2@test.com", "������ȣ����922"),
            new RankingSaveData(2960, "test3@test.com", "�������ܽ���489"),
            new RankingSaveData(2263, "test4@test.com", "�������䳢754"),
            new RankingSaveData(1552, "test5@test.com", "�Ϳ����451"),
            new RankingSaveData(2086, "test6@test.com", "�ູ�Ѱ����621"),
            new RankingSaveData(2065, "test7@test.com", "�������ܽ���558"),
            new RankingSaveData(1211, "test8@test.com", "���ְ����980"),
            new RankingSaveData(2139, "test9@test.com", "���������570"),
            new RankingSaveData(1469, "test10@test.com", "�����䳢732"),
            new RankingSaveData(2786, "test11@test.com", "�ູ�ѿ���85"),
            new RankingSaveData(2850, "test12@test.com", "�Ϳ����䳢586"),
            new RankingSaveData(3100, "test13@test.com", "��ö�Ѵ���739"),
            new RankingSaveData(3034, "test14@test.com", "��ö�ѿ���560"),
            new RankingSaveData(2446, "test15@test.com", "�����°����474"),
            new RankingSaveData(3175, "test16@test.com", "�����ѿ���884"),
            new RankingSaveData(1056, "test17@test.com", "�Ϳ����674"),
            new RankingSaveData(2492, "test18@test.com", "�ູ���ܽ���538"),
            new RankingSaveData(1527, "test19@test.com", "��ģ����342"),
            new RankingSaveData(2710, "test20@test.com", "�������䳢618"),
            new RankingSaveData(2869, "test21@test.com", "�ູ��ȣ����271"),
            new RankingSaveData(2825, "test22@test.com", "�ູ�Ѱ�35"),
            new RankingSaveData(1045, "test23@test.com", "����Ѱ����417"),
            new RankingSaveData(2503, "test24@test.com", "�ູ�Ѱ����796"),
            new RankingSaveData(2992, "test25@test.com", "�������112"),
            new RankingSaveData(2265, "test26@test.com", "�����Ѱ����669"),
            new RankingSaveData(2060, "test27@test.com", "�����ܽ���18"),
            new RankingSaveData(1108, "test28@test.com", "�����ѻ���117"),
            new RankingSaveData(1762, "test29@test.com", "��ģ�Ǵ�565"),
            new RankingSaveData(1589, "test30@test.com", "���ְ����491"),
            new RankingSaveData(2546, "test31@test.com", "�Ϳ������579"),
            new RankingSaveData(2895, "test32@test.com", "�ູ�ѿ���38"),
            new RankingSaveData(3134, "test33@test.com", "��ģ�ܽ���637"),
            new RankingSaveData(1165, "test34@test.com", "��ģ�ܽ���526"),
            new RankingSaveData(3341, "test35@test.com", "�����ѻ���758"),
            new RankingSaveData(3130, "test36@test.com", "���������159"),
            new RankingSaveData(2464, "test37@test.com", "��ö��ȣ����995"),
            new RankingSaveData(1229, "test38@test.com", "�����ѻ���524"),
            new RankingSaveData(1641, "test39@test.com", "�Ϳ����Ǵ�495"),
            new RankingSaveData(2241, "test40@test.com", "����ѿ���971"),
            new RankingSaveData(1936, "test41@test.com", "���ְ�490"),
            new RankingSaveData(1521, "test42@test.com", "�������785"),
            new RankingSaveData(1584, "test43@test.com", "�����Ѵ���857"),
            new RankingSaveData(1996, "test44@test.com", "�Ϳ����189"),
            new RankingSaveData(2161, "test45@test.com", "���ֵ�����75"),
            new RankingSaveData(1729, "test46@test.com", "�Ϳ����394"),
            new RankingSaveData(2398, "test47@test.com", "��ģȣ����739"),
            new RankingSaveData(2360, "test48@test.com", "�����Ѱ�721"),
            new RankingSaveData(1865, "test49@test.com", "�������ܽ���343"),
            new RankingSaveData(3020, "test50@test.com", "��ö��ȣ����494"),
            new RankingSaveData(1697, "test100@test.com", "�ູ���䳢588"),
        };
    }
}


public class RankingSaveData
{
    public int Score;
    public string Email;
    public string Nickname;

    public RankingSaveData(int score, string email, string name)
    {
        Score = score;
        Email = email;
        Nickname = name;
    }
}