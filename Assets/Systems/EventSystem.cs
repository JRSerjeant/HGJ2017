public static class EventSystem
{
    public delegate void EventHandlerGesetGame();
    public static event EventHandlerGesetGame _ResetGame;

    public delegate void EventHandlerNewPatientEvent();
    public static event EventHandlerNewPatientEvent _NewPatientEvent;



    public static void InvokeEventHandlerResetGame()
    {
        _ResetGame.Invoke();
    }

    public static void InvokeEventHandlerNewPatientEvent()
    {
        _NewPatientEvent.Invoke();
    }
}
