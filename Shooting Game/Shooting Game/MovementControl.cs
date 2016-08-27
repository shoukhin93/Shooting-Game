using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shooting_Game
{
    class MovementControl
    {
        private const int PLAYER_AT_DOWN_UPPER_POINT = 220;
        private const int PLAYER_AT_DOWN_DOWN_POINT = 430;
        private const int PLAYER_AT_DOWN_LEFT_POINT = 0;
        private const int PLAYER_AT_DOWN_RIGHT_POINT = 690;

        private const int PLAYER_AT_UP_UPPER_POINT = -5;
        private const int PLAYER_AT_UP_DOWN_POINT = 175;
        private const int PLAYER_AT_UP_LEFT_POINT = 0;
        private const int PLAYER_AT_UP_RIGHT_POINT = 690;

        Players player;
        public MovementControl(Players player)
        {
            this.player = player;
        }

        public bool availableLeftMove()
        {
                if (player.PlayerLocation.X   <= PLAYER_AT_DOWN_LEFT_POINT)
                    return false;           

            return true;
        }
        public bool availableRightMove()
        {
            if (player.PlayerLocation.X + (player.getPlayerCharacter.Width/2) >= PLAYER_AT_DOWN_RIGHT_POINT)
                return false;

            return true;
        }
        public bool availaveUpMove()
        {
            if(player.isPlayerAtDown)
            {
                if (player.PlayerLocation.Y <= PLAYER_AT_DOWN_UPPER_POINT)
                    return false;
            }
            else
            {
                if (player.PlayerLocation.Y - (player.getPlayerCharacter.Height / 2) < PLAYER_AT_UP_UPPER_POINT)
                    return false;
            }

            return true;
        }
        public bool availableDownMove()
        {
            if(player.isPlayerAtDown)
            {
                if (player.PlayerLocation.Y + (player.getPlayerCharacter.Height / 2) > PLAYER_AT_DOWN_DOWN_POINT)
                    return false;
            }

            else
            {
                if (player.PlayerLocation.Y + (player.getPlayerCharacter.Height / 2) >= PLAYER_AT_UP_DOWN_POINT)
                    return false;
            }

            return true;
        }

    }
}
