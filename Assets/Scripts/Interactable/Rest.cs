using UnityEngine;

public class Rest : MonoBehaviour, IInteractable
{
    //private furnitureData _item;

    public string GetInteractText()
    {
        return "[G] �޽��ϱ�";

        // ���� ������ SO�� ���� �۾����� �ʾ���
        //if (_item.DisplayName == "�޽Ŀ� ����")
        //    return "[G] ���ڿ��� �޽��ϱ�";
        //else if (_item.DisplayName == "�޽Ŀ� ħ��")
        //    return "[G] ħ�뿡�� �Ѽ��ڱ�";
    }

    public void Interact()
    {
        // �޽� �ִϸ��̼� ȣ��, �÷��̾� ���� ����
    }
}
