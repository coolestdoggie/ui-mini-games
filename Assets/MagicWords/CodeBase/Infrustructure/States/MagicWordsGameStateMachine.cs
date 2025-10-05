using Common.Services;
using Common.States;

namespace MagicWords.CodeBase.Infrustructure.States
{
    public class MagicWordsGameStateMachine : GameStateMachine
    {
        public MagicWordsGameStateMachine(AllServices services) : base(services)
        {
        }
        
        protected override void InitializeStates(AllServices services)
        {
        }
    }
}