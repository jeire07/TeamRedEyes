using UnityEngine;
using UnityEngine.UI;

public class CraftTable : MonoBehaviour, IInteractable
{
    public string GetInteractText()
    {
        return string.Format("[G] ������ �����ϱ�");
    }

    public void Interact()
    {
        Debug.Log("����â ���⸦ �����ߴ�. �ڵ尡 �̿ϼ��̴�");
        //pop up craftUI for craft
    }
}
