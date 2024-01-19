using UnityEngine;

public class Rest : MonoBehaviour, IInteractable
{
    //private furnitureData _item;

    public string GetInteractText()
    {
        return "[G] 휴식하기";

        // 가구 데이터 SO가 아직 작업되지 않았음
        //if (_item.DisplayName == "휴식용 의자")
        //    return "[G] 의자에서 휴식하기";
        //else if (_item.DisplayName == "휴식용 침대")
        //    return "[G] 침대에서 한숨자기";
    }

    public void Interact()
    {
        // 휴식 애니메이션 호출, 플레이어 상태 세팅
    }
}
