using Maze.Library;
using System.Collections.Generic;
using System.Drawing;

namespace Maze.Solver {
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController {

        private IRobot robot;
        private List<Point> robotPoints = new List<Point>();
        private bool reachedEnd = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot) {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit() {
            // Here you have to add your code

            // Trivial sample algorithm that can just move right
            int x = 0;
            int y = 0;

            robot.ReachedExit += (_, __) => reachedEnd = true;

            this.checkDirections(x, y);

            if (this.reachedEnd == false) {
                this.robot.HaltAndCatchFire();
            }

            // First try
            /*           while (!reachedEnd)
                       {
                           if (robotPoints.Contains(new Point(x, y)) == false)
                           {
                               robotPoints.Add(new Point(x, y));
                               // robot.Move(Direction.Right);
                               if (this.robot.TryMove(Direction.Right) == true)
                               {
                                   if (robotPoints.Contains(new Point(x, y)) == false)
                                   {
                                       x = x + 1;
                                       robotPoints.Add(new Point(x, y));
                                       this.robot.Move(Direction.Right);
                                   }
                               }
                               if (this.robot.TryMove(Direction.Left) == true && reachedEnd == false)
                               {
                                   if (robotPoints.Contains(new Point(x, y)) == false)
                                   {
                                       x = x - 1;
                                       robotPoints.Add(new Point(x, y));
                                       this.robot.Move(Direction.Left);
                                   }
                               }
                               if (this.robot.TryMove(Direction.Up) == true && reachedEnd == false)
                               {
                                   if (robotPoints.Contains(new Point(x, y)) == false)
                                   {
                                       y = y - 1;
                                       robotPoints.Add(new Point(x, y));
                                       this.robot.Move(Direction.Up);
                                   }
                               }
                               if (this.robot.TryMove(Direction.Down) == true && reachedEnd == false)
                               {
                                   if (robotPoints.Contains(new Point(x, y)) == false)
                                   {
                                       y = y + 1;
                                       robotPoints.Add(new Point(x, y));
                                       this.robot.Move(Direction.Down);
                                   }
                               }
                           }
                       } */

        }

        public void checkDirections(int x, int y) {
            if (this.robotPoints.Contains(new Point(x, y)) == false && this.reachedEnd == false)
            {
                this.robotPoints.Add(new Point(x, y));
                if (this.reachedEnd == false && this.robot.TryMove(Direction.Right) == true)
                {
                    this.checkDirections(x + 1, y);
                    if (this.reachedEnd == false)
                    {
                        this.robot.Move(Direction.Left);
                    }
                }
                if (this.reachedEnd == false && this.robot.TryMove(Direction.Left) == true)
                {
                    this.checkDirections(x - 1, y);
                    if (this.reachedEnd == false)
                    {
                        this.robot.Move(Direction.Right);
                    }
                }
                if (this.reachedEnd == false && robot.TryMove(Direction.Up) == true)
                {
                    this.checkDirections(x, y - 1);
                    if (this.reachedEnd == false)
                    {
                        this.robot.Move(Direction.Down);
                    }
                }
                if (this.reachedEnd == false && robot.TryMove(Direction.Down) == true)
                {
                    this.checkDirections(x, y + 1);
                    if (this.reachedEnd == false)
                    {
                        this.robot.Move(Direction.Up);
                    }
                }
            }
        }

    }
}
