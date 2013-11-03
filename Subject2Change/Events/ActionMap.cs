using Subject2Change.Components;

namespace Subject2Change
{
    class ActionMap
    {
        public static void HandleAction(string action)
        {
            if(action == "Close") GameWindow.Window.Close();

            if (StringToDirection.ActionsDict.ContainsKey(action))
            {
                EntityFactory.Player.GetComponent<Direction>()
                        .SetFlag(StringToDirection.ActionsDict[action]);
            }
        }



        public static void ReleaseAction(string action)
        {
            if (StringToDirection.ActionsDict.ContainsKey(action))
            {
                EntityFactory.Player.GetComponent<Direction>()
                        .RemoveFlag(StringToDirection.ActionsDict[action]);
            }
        }
    }
}
