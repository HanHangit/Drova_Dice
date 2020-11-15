using System;
using System.Collections.Generic;
using System.Text;
using DrovaDiceLogic.BoardLogic;
using DrovaDiceLogic.Moves;

namespace DrovaDiceLogic
{
    public abstract class APlayerAction : AAction
    {
        private int _playerID = 0;
        public int PlayerID => _playerID;

        protected APlayerAction(int id)
        {
            _playerID = id;
        }
    }
}
