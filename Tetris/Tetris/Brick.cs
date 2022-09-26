using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    abstract class Brick
    {
        public int lenght;
        public int[] X;
        public int[] Y;
        public int color;
        public int position = 0;
        public abstract bool Turn(int[,,] A, int where, int sizeX, int sizeY);
        public abstract bool Move(int[,,] A, int x, int y, int sizeX, int sizeY);
    }
}
