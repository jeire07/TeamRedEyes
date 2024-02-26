using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialState : MonoBehaviour
{
    public abstract void HandleState();
}

public class TutorialStep1State : TutorialState
{
    public override void HandleState()
    {
        // Tutorial Step 1 처리 로직
    }
}

public class TutorialStep2State : TutorialState
{
    public override void HandleState()
    {
        // Tutorial Step 2 처리 로직
    }
}

public class TutorialStep3State : TutorialState
{
    public override void HandleState()
    {
        // Tutorial Step 3 처리 로직
    }
}
