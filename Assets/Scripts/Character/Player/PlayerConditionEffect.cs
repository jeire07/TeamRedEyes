using UnityEngine;

public class PlayerConditionEffect : MonoBehaviour
{
    private Condition[] _conditions;

    private void OnEnable()
    {
        _conditions = PlayerCondition.Instance.statData.Conditions;
    }

    public void HungryPercentEffect()
    {
        float hungryPercentage = _conditions[(int)ConditionType.Hunger].CurValue;

        if (hungryPercentage >= 240)
        {
            // 체력 회복속도 상승, 플레이어 스피드 증가 //PlayerGroundData 속도값 확인
        }
        else if (hungryPercentage >= 150)
        {
            // 정상
        }
        else if (hungryPercentage >= 60)
        {
            // 달릴 수 없음, 시야 범위 줄어듬
        }
        else if (hungryPercentage > 0)
        {
            // 시야가 흐려지며 공격을 할 수 없다
        }
        else
        {

        }
    }

    public void ThirstyPercentEffect()
    {
        float thirstyPercentage = _conditions[(int)ConditionType.Thirsty].CurValue;

        if (thirstyPercentage >= 150)
        {
            // 정상
        }
        else if (thirstyPercentage >= 60)
        {
            // 어지럼증
        }
        else if (thirstyPercentage > 0)
        {
            // 매우 어지럼증
        }
        else
        {

        }
    }
}
