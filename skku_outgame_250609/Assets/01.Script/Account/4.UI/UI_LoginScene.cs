using System;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class UI_InputFields
{
    public TextMeshProUGUI ResultText;  // ��� �ؽ�Ʈ
    public TMP_InputField EmailInputField;
    public TMP_InputField NicknameInputField;
    public TMP_InputField PasswordInputField;
    public TMP_InputField PasswordComfirmInputField;
    public Button ConfirmButton;   // �α��� or ȸ������ ��ư
}

public class UI_LoginScene : MonoBehaviour
{
    [Header("�г�")]
    public GameObject LoginPanel;
    public GameObject ResisterPanel;

    [Header("�α���")]
    public UI_InputFields LoginInputFields;

    [Header("ȸ������")]
    public UI_InputFields RegisterInputFields;

    private const string PREFIX = "ID_";
    private const string SALT = "10043420";



    // ���� �����ϸ� �α��� ���ְ� ȸ�������� ���ְ�..
    private void Start()
    {
        LoginPanel.SetActive(true);
        ResisterPanel.SetActive(false);

        LoginInputFields.ResultText.text = string.Empty;
        RegisterInputFields.ResultText.text = string.Empty;
    }

    // ȸ�������ϱ� ��ư Ŭ��
    public void OnClickGoToResisterButton()
    {
        LoginPanel.SetActive(false);
        ResisterPanel.SetActive(true);
    }

    public void OnClickGoToLoginButton()
    {
        LoginPanel.SetActive(true);
        ResisterPanel.SetActive(false);
    }


    // ȸ������
    public void Resister()
    {
        // 1. �̸��� ������ ��Ģ�� Ȯ���Ѵ�.
        string email = RegisterInputFields.EmailInputField.text;
        var emailSpecification = new AccountEmailSpecification();
        if (!emailSpecification.IsSatisfiedBy(email))
        {
            RegisterInputFields.ResultText.text = emailSpecification.ErrorMessage;
            return;
        }

        // 2. �г��� ������ ��Ģ�� Ȯ���Ѵ�.
        string nickname = RegisterInputFields.NicknameInputField.text;
        var nicknameSpecification = new AccountNicknameSpecification();
        if (!nicknameSpecification.IsSatisfiedBy(nickname))
        {
            RegisterInputFields.ResultText.text = nicknameSpecification.ErrorMessage;
            return;
        }

        // 2. 1�� ��й�ȣ �Է��� Ȯ���Ѵ�.
        string password = RegisterInputFields.PasswordInputField.text;
        var passwordSpecification = new AccountPasswordSpecification();
        if (!passwordSpecification.IsSatisfiedBy(password))
        {
            RegisterInputFields.ResultText.text = passwordSpecification.ErrorMessage;
            return;
        }

        // 3. 2�� ��й�ȣ �Է��� Ȯ���ϰ�, 1�� ��й�ȣ �Է°� ������ Ȯ���Ѵ�.
        string password2 = RegisterInputFields.PasswordComfirmInputField.text;
        if (!passwordSpecification.IsSatisfiedBy(password2))
        {
            RegisterInputFields.ResultText.text = passwordSpecification.ErrorMessage;
            return;
        }

        if (password != password2)
        {
            RegisterInputFields.ResultText.text = "��й�Ȥ�� �ٸ��ϴ�.";
            return;
        }

        Result result = AccountManager.Instance.TryRegister(email, nickname, password);
        if (result.IsSuccess)
        {
            OnClickGoToLoginButton();
        }
        else
        {
            RegisterInputFields.ResultText.text = result.Message;
        }
    }


    public void Login()
    {
        // 1. �̸��� �Է��� Ȯ���Ѵ�.
        string email = LoginInputFields.EmailInputField.text;
        var emailSpecification = new AccountEmailSpecification();
        if (!emailSpecification.IsSatisfiedBy(email))
        {
            LoginInputFields.ResultText.text = emailSpecification.ErrorMessage;
            return;
        }

        // 2. ��й�ȣ �Է��� Ȯ���Ѵ�.
        string password = LoginInputFields.PasswordInputField.text;
        var passwordSpecification = new AccountPasswordSpecification();
        if (!passwordSpecification.IsSatisfiedBy(password))
        {
            LoginInputFields.ResultText.text = passwordSpecification.ErrorMessage;
            return;
        }

        if (AccountManager.Instance.TryLogin(email, password))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            LoginInputFields.ResultText.text = "�̸��� �ߺ��Ǿ����ϴ�.";
        }
    }
}
