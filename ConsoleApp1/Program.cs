using System;
using System.Collections.Generic;

namespace EmergencyResponseSimulator
{
    // Abstract base class
    abstract class EmergencyUnit
    {
        public string Name { get; set; }
        public int Speed { get; set; } // Units: km/h

        public EmergencyUnit(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public abstract bool CanHandle(string incidentType);
        public abstract void RespondToIncident(Incident incident, int responseTime);
    }

    // Units
    class Police : EmergencyUnit
    {
        public Police(string name, int speed) : base(name, speed) { }
        public override bool CanHandle(string incidentType) => incidentType == "Crime";
        public override void RespondToIncident(Incident incident, int responseTime)
        {
            Console.WriteLine($"{Name} is handling a crime at {incident.Location}. Response Time: {responseTime} sec.");
        }
    }

    class Firefighter : EmergencyUnit
    {
        public Firefighter(string name, int speed) : base(name, speed) { }
        public override bool CanHandle(string incidentType) => incidentType == "Fire";
        public override void RespondToIncident(Incident incident, int responseTime)
        {
            Console.WriteLine($"{Name} is extinguishing a fire at {incident.Location}. Response Time: {responseTime} sec.");
        }
    }

    class Ambulance : EmergencyUnit
    {
        public Ambulance(string name, int speed) : base(name, speed) { }
        public override bool CanHandle(string incidentType) => incidentType == "Medical";
        public override void RespondToIncident(Incident incident, int responseTime)
        {
            Console.WriteLine($"{Name} is treating patients at {incident.Location}. Response Time: {responseTime} sec.");
        }
    }

    class RescueTeam : EmergencyUnit
    {
        public RescueTeam(string name, int speed) : base(name, speed) { }
        public override bool CanHandle(string incidentType) => incidentType == "Disaster";
        public override void RespondToIncident(Incident incident, int responseTime)
        {
            Console.WriteLine($"{Name} is conducting rescue operations at {incident.Location}. Response Time: {responseTime} sec.");
        }
    }

    // Incident class
    class Incident
    {
        public string Type { get; set; }
        public string Location { get; set; }
        public int Difficulty { get; set; }

        public Incident(string type, string location, int difficulty)
        {
            Type = type;
            Location = location;
            Difficulty = difficulty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();

            string[] incidentTypes = { "Fire", "Crime", "Medical", "Disaster" };
            string[] locations = { "Central Park", "City Hall", "Downtown", "Airport", "Museum", "Library", "Industrial Zone" };

            List<EmergencyUnit> units = new List<EmergencyUnit>
            {
                new Police("Police Unit 1", 80),
                new Firefighter("Firefighter Unit 1", 70),
                new Ambulance("Ambulance Unit 1", 90),
                new RescueTeam("Rescue Team Alpha", 60)
            };

            int score = 0;

            for (int turn = 1; turn <= 5; turn++)
            {
                Console.WriteLine($"\n--- Turn {turn} ---");

                // Show available incident types
                Console.WriteLine("Incident Types:");
                for (int i = 0; i < incidentTypes.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {incidentTypes[i]}");
                }

                int incidentChoice;
                Console.Write("Choose an incident type by number: ");
                while (!int.TryParse(Console.ReadLine(), out incidentChoice) || incidentChoice < 1 || incidentChoice > incidentTypes.Length)
                {
                    Console.Write("Invalid input. Choose again: ");
                }

                string selectedIncidentType = incidentTypes[incidentChoice - 1];

                // Show location choices
                Console.WriteLine("Incident Locations:");
                for (int i = 0; i < locations.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {locations[i]}");
                }

                int locationChoice;
                Console.Write("Choose a location by number: ");
                while (!int.TryParse(Console.ReadLine(), out locationChoice) || locationChoice < 1 || locationChoice > locations.Length)
                {
                    Console.Write("Invalid input. Choose again: ");
                }

                string selectedLocation = locations[locationChoice - 1];

                int difficulty = rand.Next(1, 4); // 1 (easy) to 3 (hard)

                Incident incident = new Incident(selectedIncidentType, selectedLocation, difficulty);
                Console.WriteLine($"Incident: {incident.Type} at {incident.Location} | Difficulty: {incident.Difficulty}");

                // Show ALL units and let user choose
                Console.WriteLine("Available Units:");
                for (int i = 0; i < units.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {units[i].Name} - Speed: {units[i].Speed} km/h - Can Handle: {units[i].CanHandle(incident.Type)}");
                }

                int unitChoice;
                Console.Write("Choose a unit by number: ");
                while (!int.TryParse(Console.ReadLine(), out unitChoice) || unitChoice < 1 || unitChoice > units.Count)
                {
                    Console.Write("Invalid choice. Try again: ");
                }

                EmergencyUnit selectedUnit = units[unitChoice - 1];

                if (!selectedUnit.CanHandle(incident.Type))
                {
                    Console.WriteLine($"{selectedUnit.Name} cannot handle this type of incident.");
                    Console.WriteLine("-5 points");
                    score -= 5;
                }
                else
                {
                    int distance = rand.Next(5, 21);
                    int responseTime = (int)((distance / (double)selectedUnit.Speed) * 60); // minutes to seconds

                    selectedUnit.RespondToIncident(incident, responseTime);

                    int turnScore = 10 + (responseTime < 10 ? 5 : 0) - (incident.Difficulty * 2);
                    Console.WriteLine($"{(turnScore >= 0 ? "+" : "")}{turnScore} points");

                    score += turnScore;
                }

                Console.WriteLine($"Current Score: {score}");
            }

            Console.WriteLine($"\nFinal Score: {score}");
            Console.WriteLine("Simulation complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
