using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameField
    {
        public int sizeX, sizeY;
        public int[,,] fieldData;
        public Brick brick;

        public GameField(int x, int y, Brick b)
        {
            sizeX = x;
            sizeY = y;
            fieldData = new int[x, y, 2];
            brick = b;
            for (int i = 0; i < brick.lenght; i++)
            {
                fieldData[brick.X[i], brick.Y[i], 0] = 2;
                fieldData[brick.X[i], brick.Y[i], 1] = brick.color;
            }
        }

        public void ChangeBrick(int color, int x, int y)
        {
            brick = new TetraBrick(color, x, y);
            Update();
        }

        private void Update()
        {
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (fieldData[i, j, 0] == 2)
                    {
                        fieldData[i, j, 0] = 0;
                    }
                }
            }
            for (int i = 0; i < brick.lenght; i++)
            {
                fieldData[brick.X[i], brick.Y[i], 0] = 2;
                fieldData[brick.X[i], brick.Y[i], 1] = brick.color;
            }
        }

        public int[] MoveBrick(int x, int y)
        {
            int[] retData = { 0, 0 };
            bool test = brick.Move(fieldData, x, y, sizeX, sizeY);
            if (!test && y == 1)
            {
                retData[0] = 2;
                for (int i = 0; i < brick.lenght; i++)
                {
                    fieldData[brick.X[i], brick.Y[i], 0] = 1;
                }
                int n = 0;
                for (int j = sizeY - 1; j >= 0; j--)
                {
                    bool destTest = true;
                    for (int i = 0; i < sizeX; i++)
                    {
                        if (fieldData[i, j, 0] == 0)
                        {
                            destTest = false;
                            break;
                        }
                    }
                    if (destTest)
                    {
                        n++;
                        for (int k = j - 1; k >= 0; k--)
                        {
                            for (int i = 0; i < sizeX; i++)
                            {
                                fieldData[i, k + 1, 0] = fieldData[i, k, 0];
                                fieldData[i, k + 1, 1] = fieldData[i, k, 1];
                            }
                        }
                        j++;
                    }
                }
                retData[1] = n;
                for (int i = 0; i < sizeX; i++)
                {
                    if (fieldData[i, 1, 0] == 1)
                    {
                        retData[0] = 3;
                        break;
                    }
                }
            }
            else if (test)
            {
                retData[0] = 1;
                Update();
            }
            return retData;
        }

        public bool TurnBrick(int where)
        {
            bool test = brick.Turn(fieldData, where, sizeX, sizeY);
            if (test)
            {
                Update();
            }
            return test;
        }
    }
}
