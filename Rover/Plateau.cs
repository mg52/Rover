using System;
using System.Collections.Generic;

namespace Rover
{
    public class Plateau
    {
        public int x;
        public int y;
        public List<Rover> roverList;

        public Plateau(string coordinateString)
        {
            try
            {
                if(Int32.Parse(coordinateString.Split(' ')[0]) > 0)
                {
                    x = Int32.Parse(coordinateString.Split(' ')[0]);
                }
                else
                {
                    throw new Exception("Plateau coordinates must be greater than 0.");
                }

                if (Int32.Parse(coordinateString.Split(' ')[1]) > 0)
                {
                    y = Int32.Parse(coordinateString.Split(' ')[1]);
                }
                else
                {
                    throw new Exception("Plateau coordinates must be greater than 0.");
                }

                roverList = new List<Rover>();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRoverToPlateau(Rover newRover)
        {
            foreach (var rover in roverList)
            {
                if(newRover.x == rover.x && newRover.y == rover.y)
                {
                    throw new Exception("There is already a rover at this coordinates.");
                }
            }

            roverList.Add(newRover);
            return true;
        }
    }
}
