using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerConditionEffect : MonoBehaviour
{
    public PlayerCondition PlayerCondition;

    public void HungryPercentEffect()
    {
        float hungryPercentage = PlayerCondition.Hunger.ValuePercentage();

        if (hungryPercentage >= 80)
        {
            // 체력 회복속도 상승, 플레이어 스피드 증가 //PlayerGroundData 속도값 확인
        }
        else if (hungryPercentage >= 50)
        {
            // 정상
        }
        else if (hungryPercentage >= 20)
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
        float thirstyPercentage = PlayerCondition.Thirsty.ValuePercentage();

        if (thirstyPercentage >= 50)
        {
            // 정상
        }
        else if (thirstyPercentage >= 20)
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

