using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform handTransform; // 인스펙터에서 설정: 무기를 장착할 손의 위치
    private GameObject currentWeapon; // 현재 장착된 무기를 추적

    // 무기를 장착하는 함수
    public void EquipWeapon(GameObject weaponPrefab)
    {
        // 이미 무기가 장착되어 있다면 제거
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // 새 무기를 생성하여 손의 위치에 장착
        currentWeapon = Instantiate(weaponPrefab, handTransform);
        currentWeapon.transform.localPosition = Vector3.zero; // 위치 조정
        currentWeapon.transform.localRotation = Quaternion.identity; // 회전 조정
    }
}