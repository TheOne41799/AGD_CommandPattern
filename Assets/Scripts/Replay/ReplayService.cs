using Command.Commands;
using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace Command.ReplayFunction
{
    public class ReplayService : MonoBehaviour
    {
        private Stack<ICommand> replayCommandStack;

        public ReplayState ReplayState { get; private set; }

        public ReplayService() => SetReplayState(ReplayState.DEACTIVE);

        public void SetReplayState(ReplayState stateToSet) => ReplayState = stateToSet;

        public void SetCommandStack(Stack<ICommand> commandsToSet) => replayCommandStack = new Stack<ICommand>(commandsToSet);

        public void ExecuteNext()
        {
            if (replayCommandStack.Count > 0)
                GameService.Instance.ProcessUnitCommand(replayCommandStack.Pop());
        }
    }
}