using System;
using System.Collections.Generic;

namespace Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Plateau Coordinates: ");
            var plateauCoordinates = Console.ReadLine();
            var plateau = new Plateau(plateauCoordinates);
            Console.WriteLine("Plateau Coordinates: " + plateau.x + ", " + plateau.y);

            var roverSerialNo = 0;
            while (true)
            {
                Console.Write("Enter Rover Coordinates (To quit type Q): ");
                var roverCoordinates = Console.ReadLine();
                if (String.IsNullOrEmpty(roverCoordinates) || roverCoordinates == "Q")
                {
                    break;
                }
                var rover = new Rover(roverCoordinates, plateau, roverSerialNo);

                plateau.AddRoverToPlateau(rover);

                Console.Write("Enter Rover Command: ");
                var roverCommand = Console.ReadLine();
                rover.GetCommand(roverCommand);

                roverSerialNo++;
            }

            foreach (var item in plateau.roverList)
            {
                var result = item.ExecuteCommand();
                Console.WriteLine(result);
            }
        }
    }
}
