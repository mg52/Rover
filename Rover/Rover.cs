using System;
namespace Rover
{
    public class Rover
    {
        public int x;
        public int y;
        public int heading;
        public int serialNo;
        public string roverCommandString;
        public Plateau plateau;

        public Rover(string roverInitString, Plateau p, int s)
        {
            try
            {
                serialNo = s;
                plateau = p;
                if(Int32.Parse(roverInitString.Split(' ')[0]) > p.x || Int32.Parse(roverInitString.Split(' ')[0]) < 0)
                {
                    throw new Exception("Rover X Coordinate must be in the plateau X coordinate.");
                }
                else
                {
                    x = Int32.Parse(roverInitString.Split(' ')[0]);
                }

                if (Int32.Parse(roverInitString.Split(' ')[1]) > p.y || Int32.Parse(roverInitString.Split(' ')[1]) < 0)
                {
                    throw new Exception("Rover Y Coordinate must be in the plateau Y coordinate.");
                }
                else
                {
                    y = Int32.Parse(roverInitString.Split(' ')[1]);
                }

                Compass myEnum = (Compass)Enum.Parse(typeof(Compass), roverInitString.Split(' ')[2]);
                heading = (int)myEnum;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCommand(string commandString)
        {
            if (String.IsNullOrEmpty(commandString))
            {
                throw new Exception("Command String cannot be empty.");
            }

            var charArray = commandString.ToCharArray();
            foreach (var item in charArray)
            {
                if(item != 'M' && item != 'L' && item != 'R')
                {
                    throw new Exception("Commands can only be Move(M), Left(L) and Right(R).");
                }
            }
            roverCommandString = commandString;
        }

        public string ExecuteCommand()
        {
            var charArray = roverCommandString.ToCharArray();

            foreach (var item in charArray)
            {
                if(item == 'M')
                {
                    Move();
                }else if(item == 'L')
                {
                    Turn('L');
                }
                else if (item == 'R')
                {
                    Turn('R');
                }
            }

            return x.ToString() + " " + y.ToString() + " " + (Compass)heading;
        }

        private void Turn(char ch)
        {
            if(ch == 'L')
            {
                heading = (heading - 1) % 4;
                if(heading == -1)
                {
                    heading = 3;
                }
            }
            else if (ch == 'R')
            {
                heading = (heading + 1) % 4;
            }
        }

        private void Move()
        {
            if(heading == (int)Compass.N)
            {
                if(y == plateau.y)
                {
                    throw new Exception("Rover Y Coordinate cannot be greater than plateau Y coordinate.");
                }
                else
                {
                    foreach (var item in plateau.roverList)
                    {
                        if(serialNo != item.serialNo)
                        {
                            if(x == item.x && y+1 == item.y)
                            {
                                throw new Exception("There is another rover in the way.");
                            }
                        }
                    }
                    y += 1;
                }
            }else if(heading == (int)Compass.E)
            {
                if (x == plateau.x)
                {
                    throw new Exception("Rover X Coordinate cannot be greater than plateau X coordinate.");
                }
                else
                {
                    foreach (var item in plateau.roverList)
                    {
                        if (serialNo != item.serialNo)
                        {
                            if (x + 1 == item.x && y == item.y)
                            {
                                throw new Exception("There is another rover in the way.");
                            }
                        }
                    }
                    x += 1;
                }
            }
            else if (heading == (int)Compass.S)
            {
                if (y == 0)
                {
                    throw new Exception("Rover Y Coordinate cannot be lower than 0");
                }
                else
                {
                    foreach (var item in plateau.roverList)
                    {
                        if (serialNo != item.serialNo)
                        {
                            if (x == item.x && y - 1 == item.y)
                            {
                                throw new Exception("There is another rover in the way.");
                            }
                        }
                    }
                    y -= 1;
                }
            }
            else if (heading == (int)Compass.W)
            {
                if (x == 0)
                {
                    throw new Exception("Rover X Coordinate cannot be lower than 0");
                }
                else
                {
                    foreach (var item in plateau.roverList)
                    {
                        if (serialNo != item.serialNo)
                        {
                            if (x - 1 == item.x && y == item.y)
                            {
                                throw new Exception("There is another rover in the way.");
                            }
                        }
                    }
                    x -= 1;
                }
            }
        }

    }
}
