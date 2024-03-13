using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class ActionsHistory
    {
        private static ActionsHistory instance;

        private List<DrawingAction> drawingActions;

        private ActionsHistory()
        {
            drawingActions = new List<DrawingAction>();
        }

        public static ActionsHistory getInstance()
        {
            if (instance == null)
                instance = new ActionsHistory();
            return instance;
        }
    }
}
