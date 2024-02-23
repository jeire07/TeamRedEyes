using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
    public TutorialState currentState;

    public void ProceedToNextStep()
    {
        if (currentState != null)
        {
            currentState.HandleState();
            currentState = GetNextState(currentState);
        }
    }

    private TutorialState GetNextState(TutorialState currentState)
    {
        if (currentState is TutorialStep1State)
        {
            return new TutorialStep2State();
        }
        else if (currentState is TutorialStep2State)
        {
            return new TutorialStep3State();
        }
        else
        {
            return null;
        }
    }
}
