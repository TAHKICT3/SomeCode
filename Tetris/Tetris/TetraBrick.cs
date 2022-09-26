using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{

    class TetraBrick : Brick
    {

        public TetraBrick(int color, int x, int y)
        {
            lenght = 4;
            X = new int[4];
            Y = new int[4];
            this.color = color;
            switch (color)
            {
                case 0:
                    X[0] = x - 1;
                    X[1] = x;
                    X[2] = x + 1;
                    X[3] = x + 2;
                    Y[0] = y;
                    Y[1] = y;
                    Y[2] = y;
                    Y[3] = y;
                    break;
                case 1:
                    X[0] = x;
                    X[1] = x;
                    X[2] = x + 1;
                    X[3] = x + 2;
                    Y[0] = y - 1;
                    Y[1] = y;
                    Y[2] = y;
                    Y[3] = y;
                    break;
                case 2:
                    X[0] = x;
                    X[1] = x + 1;
                    X[2] = x + 2;
                    X[3] = x + 2;
                    Y[0] = y;
                    Y[1] = y;
                    Y[2] = y;
                    Y[3] = y - 1;
                    break;
                case 3:
                    X[0] = x;
                    X[1] = x;
                    X[2] = x + 1;
                    X[3] = x +1;
                    Y[0] = y - 1;
                    Y[1] = y;
                    Y[2] = y - 1;
                    Y[3] = y;
                    break;
                case 4:
                    X[0] = x;
                    X[1] = x + 1;
                    X[2] = x + 1;
                    X[3] = x + 2;
                    Y[0] = y;
                    Y[1] = y;
                    Y[2] = y - 1;
                    Y[3] = y - 1;
                    break;
                case 5:
                    X[0] = x;
                    X[1] = x + 1;
                    X[2] = x + 1;
                    X[3] = x + 2;
                    Y[0] = y;
                    Y[1] = y;
                    Y[2] = y - 1;
                    Y[3] = y;
                    break;
                case 6:
                    X[0] = x;
                    X[1] = x + 1;
                    X[2] = x + 1;
                    X[3] = x + 2;
                    Y[0] = y - 1;
                    Y[1] = y;
                    Y[2] = y - 1;
                    Y[3] = y;
                    break;
            }
        }

        public override bool Turn(int[,,] A, int where, int x, int y)
        {
            bool turnCheck = true;
            int[,] test = new int[4, 2];
            test[1, 0] = X[1];
            test[1, 1] = Y[1];
            int newPosition = position + where;
            if (newPosition > 3)
            {
                newPosition = 0;
            }
            else if (newPosition < 0)
            {
                newPosition = 3;
            }
            switch (color)
            {
                case 0:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] + 2;
                            test[3, 1] = test[1, 1];
                            break;
                        case 1:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] + 2;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] - 2;
                            test[3, 1] = test[1, 1];
                            break;
                        case 3:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] - 2;
                            break;
                    }
                    break;
                case 1:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] + 2;
                            test[3, 1] = test[1, 1];
                            break;
                        case 1:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] + 2;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] - 2;
                            test[3, 1] = test[1, 1];
                            break;
                        case 3:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] - 2;
                            break;
                    }
                    break;
                case 2:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1] - 1;
                            break;
                        case 1:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 3:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1] - 1;
                            break;
                    }
                    break;
                case 3:
                    test[0, 0] = X[0];
                    test[0, 1] = Y[0];
                    test[1, 0] = X[1];
                    test[1, 1] = Y[1];
                    test[2, 0] = X[2];
                    test[2, 1] = Y[2];
                    test[3, 0] = X[3];
                    test[3, 1] = Y[3];
                    break;
                case 4:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1] - 1;
                            break;
                        case 1:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 3:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1] - 1;
                            break;
                    }
                    break;
                case 5:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1];
                            break;
                        case 1:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1];
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1];
                            break;
                        case 3:
                            test[0, 0] = test[1, 0];
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] - 1;
                            break;
                    }
                    break;
                case 6:
                    switch (newPosition)
                    {
                        case 0:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] - 1;
                            test[3, 0] = test[1, 0] + 1;
                            test[3, 1] = test[1, 1];
                            break;
                        case 1:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1] - 1;
                            test[2, 0] = test[1, 0] + 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] + 1;
                            break;
                        case 2:
                            test[0, 0] = test[1, 0] + 1;
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0];
                            test[2, 1] = test[1, 1] + 1;
                            test[3, 0] = test[1, 0] - 1;
                            test[3, 1] = test[1, 1];
                            break;
                        case 3:
                            test[0, 0] = test[1, 0] - 1;
                            test[0, 1] = test[1, 1] + 1;
                            test[2, 0] = test[1, 0] - 1;
                            test[2, 1] = test[1, 1];
                            test[3, 0] = test[1, 0];
                            test[3, 1] = test[1, 1] - 1;
                            break;
                    }
                    break;
            }
            for (int i = 0; i < 4; i++)
            {
                if ((test[i,1] > y - 1 || test[i, 1] < 0 || test[i, 0] > x - 1 || test[i, 0] < 0) || A[test[i, 0], test[i, 1], 0] == 1)
                {
                    turnCheck = false;
                    break;
                }
            }
            if (turnCheck)
            {
                for (int i = 0; i < 4; i++)
                {
                    X[i] = test[i, 0];
                    Y[i] = test[i, 1];
                }
                position = newPosition;
            }
            return turnCheck;
        }

        public override bool Move(int[,,] A, int x, int y, int sizeX, int sizeY)
        {
            bool test = true;
            for (int i = 0; i < 4; i++)
            {
                if (X[i] + x < 0 || X[i] + x > sizeX - 1 || Y[i] + y < 0 || Y[i] + y > sizeY - 1 || A[X[i] + x, Y[i] + y, 0] == 1)
                {
                    test = false;
                    break;
                }
            }
            if (test)
            {
                for (int i = 0; i < 4; i++)
                {
                    X[i] = X[i] + x;
                    Y[i] = Y[i] + y;
                }
            }
            return test;
        }
    }
}
