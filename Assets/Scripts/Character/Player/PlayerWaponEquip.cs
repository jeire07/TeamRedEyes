using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform handTransform; // �ν����Ϳ��� ����: ���⸦ ������ ���� ��ġ
    private GameObject currentWeapon; // ���� ������ ���⸦ ����

    // ���⸦ �����ϴ� �Լ�
    public void EquipWeapon(GameObject weaponPrefab)
    {
        // �̹� ���Ⱑ �����Ǿ� �ִٸ� ����
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // �� ���⸦ �����Ͽ� ���� ��ġ�� ����
        currentWeapon = Instantiate(weaponPrefab, handTransform);
        currentWeapon.transform.localPosition = Vector3.zero; // ��ġ ����
        currentWeapon.transform.localRotation = Quaternion.identity; // ȸ�� ����
    }
}