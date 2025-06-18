public class AccountPasswordSpecification : ISpecification<string>
{
    public bool IsSatisfiedBy(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            ErrorMessage = "��й�ȣ�� ������� �� �����ϴ�.";
            return false;
        }


        if (value.Length < 6 || 12 < value.Length)
        {
            ErrorMessage = "��й�ȣ�� 6�� �̻� 12�� �����̾�� �մϴ�.";
            return false;
        }

        return true;
    }

    public string ErrorMessage { get; private set; }
}