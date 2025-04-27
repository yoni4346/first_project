Emergency Response Simulator

Developed by: Yonas Tilahun

Project Description:

The Emergency Response Simulator is a simple console-based C# application that simulates the operation of emergency response units (Police, Firefighters, and Ambulances) handling various types of incidents in different locations. The program randomly generates incidents and selects the appropriate emergency unit to handle the situation based on the incident type. Each unit can handle specific types of incidents, and the program rewards or penalizes the user based on the unit's ability to respond to the incident.

Features:
Emergency Unit Classes: The simulator has an abstract EmergencyUnit class and specialized subclasses (Police, Firefighter, Ambulance) that implement different types of emergency response units.

Incident Types: Incidents are randomly generated, with three main types: "Fire", "Crime", and "Medical", each requiring a specific type of emergency unit to respond.

Scoring System: A simple scoring system that adds points when the correct unit responds to an incident and deducts points when no unit can handle the incident.

Turn-Based Gameplay: The simulation runs for five turns, each representing a new round of randomly generated incidents, where the user can observe how well the units handle the situations.

Real-Time Feedback: The program provides real-time feedback about the status of each incident and the current score.

Classes:
EmergencyUnit (Abstract): Base class for all emergency response units, defining properties like Name and Speed, as well as abstract methods to check if a unit can handle an incident and to respond to it.

Police: Handles incidents of type "Crime".

Firefighter: Handles incidents of type "Fire".

Ambulance: Handles incidents of type "Medical".

Incident: Represents an incident with a specific type (Fire, Crime, or Medical) and location.

How It Works:
Initialization: The simulation initializes a list of emergency units (Police, Firefighters, and Ambulances) with different speeds.

Random Incident Generation: In each turn, an incident is randomly generated, consisting of a type and a location.

Unit Selection: The simulator checks which unit can handle the incident and calls the appropriate RespondToIncident method.

Scoring: If the correct unit handles the incident, the user earns 10 points. If no unit can handle it, the user loses 5 points.

End of Simulation: After five turns, the final score is displayed.

Example Output:
vbnet
Copy
Edit
--- Turn 1 ---
Incident: Fire at Downtown
Firefighter Unit 1 is extinguishing a fire at Downtown.
+10 points
Current Score: 10

--- Turn 2 ---
Incident: Medical at Airport
Ambulance Unit 1 is treating patients at Airport.
+10 points
Current Score: 20

--- Turn 3 ---
Incident: Crime at Library
Police Unit 1 is handling a crime at Library.
+10 points
Current Score: 30

...

Final Score: 45
Simulation complete. Press any key to exit.
Requirements:
.NET Core (or .NET Framework) for compiling and running the application.

C# programming language knowledge.

How to Run:
Clone the repository or download the project files.

Open the project in Visual Studio or any C# IDE.

Build and run the application.

The console window will display incidents and respond to them based on the units available.
