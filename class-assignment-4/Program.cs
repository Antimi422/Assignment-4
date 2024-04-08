using Clients;

Client myClient = new();
bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
        if (mainMenuChoice == "N")
            myClient = NewClient();
        if (mainMenuChoice == "S")
            ShowClientInfo(myClient);
        if (mainMenuChoice == "Q")
        {
            loopAgain = false;
            throw new Exception("Bye");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}



void DisplayMainMenu()
{
    Console.WriteLine("\n/------------------------------/");
    Console.WriteLine("     Personal Training App      ");
    Console.WriteLine("/------------------------------/");
    Console.WriteLine("");
    Console.WriteLine("\nMenu Options");
    Console.WriteLine("===============");
    Console.WriteLine("[N]ew client");
    Console.WriteLine("[S]how client BMI info");
    Console.WriteLine("[E]dit client");
    Console.WriteLine("[Q]uit");
}

void ShowClientInfo(Client client)
{
    if (client == null)
        throw new Exception("No client in memory");
    Console.WriteLine("\n=== Client Info ===");
    Console.WriteLine($"Client Name:    {client.FullName}");
    Console.WriteLine($"BMI Score:      {client.BMIScore}");
    Console.WriteLine($"BMI Status:     {client.BMIStatus}");
}

string Prompt(string prompt)
{
    string myString = "";
    while (true)
    {
        try
        {
            Console.Write(prompt);
            myString = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(myString))
                throw new Exception($"Empty Input: Please enter something.");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    return myString;
}

double PromptDouble(string msg, double min)
{
    double num = 0;
    while (true)
    {
        try
        {
            Console.Write($"{msg}");
            num = double.Parse(Console.ReadLine());
            if (num <= 0)
                throw new Exception($"Must be bigger than {min}");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid: {ex.Message}");
        }
    }
    return num;
}

Client NewClient()
{
    Client myClient = new();
    GetFirstName(myClient);
    GetLastName(myClient);
    GetWeight(myClient);
    GetHeight(myClient);
    Console.WriteLine("\nClient Sucessfully Created.");
    return myClient;
}

void GetFirstName(Client client)
{
    string myString = Prompt("Enter client's First Name: ");
    client.FirstName = myString;
}

void GetLastName(Client client)
{
    string myString = Prompt("Enter client's Last Name: ");
    client.LastName = myString;
}

void GetWeight(Client client)
{
    double myDouble = PromptDouble("Enter client's weight in pounds: ", 0);
    client.Weight = myDouble;
}

void GetHeight(Client client)
{
    double myDouble = PromptDouble("Enter the client's height in inches: ", 0);
    client.Height = myDouble;
}