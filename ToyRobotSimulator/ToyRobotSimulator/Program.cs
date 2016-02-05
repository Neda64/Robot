using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public enum Direction { NORTH, EAST, SOUTH, WEST };

    public class Robot
    {
        private int x;
        private int y;
        private Direction direction;
        private int max_x;
        private int max_y;
        private const int min_x = 0;
        private const int min_y = 0;
        private int count = 0;


        public Robot()
        {
            max_x = 100;
            max_y = 100;

        }

        public Robot(int max_X, int max_Y)
        {
            max_x = max_X;
            max_y = max_Y;
        }

        public void PLACE(int ini_x, int ini_y, Direction ini_direction)
        {
            if (!pointIsValid(ini_x, ini_y))
                throw new System.ArgumentException("Parameters are not in the range...");

            x = ini_x;
            y = ini_y;
            direction = ini_direction;
        }

        public void MOVE()
        {
            int new_x = x;
            int new_y = y;

            switch (direction)
            {
                case Direction.NORTH:
                    new_y++;
                    break;
                case Direction.EAST:
                    new_x++;
                    break;
                case Direction.SOUTH:
                    new_y--;
                    break;
                case Direction.WEST:
                    new_x--;
                    break;
            }
            if (pointIsValid(new_x, new_y))
            {
                x = new_x;
                y = new_y;
            }
            else
                throw new System.ArgumentException("New movement is out of range...");
        }

        public void LEFT()
        {
            switch (direction)
            {
                case Direction.NORTH:
                    direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    direction = Direction.NORTH;
                    break;
                case Direction.SOUTH:
                    direction = Direction.EAST;
                    break;
                case Direction.WEST:
                    direction = Direction.SOUTH;
                    break;
            }
        }

        public void RIGHT()
        {
            switch (direction)
            {
                case Direction.NORTH:
                    direction = Direction.EAST;
                    break;
                case Direction.EAST:
                    direction = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    direction = Direction.WEST;
                    break;
                case Direction.WEST:
                    direction = Direction.NORTH;
                    break;
            }


        }

        public void REPORT()
        {
            count++;
            Console.WriteLine("The outpout for Case {0} is  ({1} , {2} , {3})", count.ToString(), x.ToString(), y.ToString(), direction);

        }
        private bool pointIsValid(int new_x, int new_y)
        {
            bool valid = true;
            if ((new_x < min_x) || (new_x > max_x) || (new_y < min_y) || (new_y > max_y))
                valid = false;
            return valid;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Robot robot = new Robot(150, 150);

                robot.PLACE(0, 0, Direction.NORTH);
                robot.MOVE();
                robot.REPORT();

                robot.PLACE(0, 0, Direction.NORTH);
                robot.LEFT();
                robot.REPORT();

                robot.PLACE(1, 2, Direction.EAST);
                robot.MOVE();
                robot.MOVE();
                robot.LEFT();
                robot.MOVE();
                robot.REPORT();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            Console.ReadKey();
        }
    }
}
