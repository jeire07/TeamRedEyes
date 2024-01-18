using UnityEngine;

public class CraftTable : MonoBehaviour, IInteractable
{
    public string GetInteractText()
    {
        return "[G] 작업대 - 아이템 제작하기";
    }

    public void Interact()
    {
        Debug.Log("제작창 열기를 시전했다. 코드가 미완성이다");
        //pop up craftUI for craft
    }
}
