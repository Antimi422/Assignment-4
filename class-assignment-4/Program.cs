using Clients;

Client myClient = new();
List<Client> listOfClients = new List<Client>();

LoadFileValuesToMemory(listOfClients);


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
        if (mainMenuChoice == "F")
            myClient = FindClientInList(listOfClients);
        if (mainMenuChoice == "R")
            RemoveClientFromList(myClient, listOfClients);
        if (mainMenuChoice == "L")
            ListAllClient(listOfClients);
        if (mainMenuChoice == "E")
        {
            while (true)
            {
                DisplayEditMenu();
                string editMenuChoice = Prompt("\nEnter a Edit Menu Choice: ").ToUpper();
                if (editMenuChoice == "F")
                    GetFirstName(myClient);
                if (editMenuChoice == "L")
                    GetLastName(myClient);
                if (editMenuChoice == "H")
                    GetHeight(myClient);
                if (editMenuChoice == "W")
                    GetWeight(myClient);
                if (editMenuChoice == "R")
                    throw new Exception("Returning to Main Menu");
            }
        }
        if (mainMenuChoice == "Q")
        {
            SaveMemoryValuesToFile(listOfClients);
            loopAgain = false;
            throw new Exception("Bye, hope to see you again");
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
    Console.WriteLine("[F]ind client");
    Console.WriteLine("[R]emove client");
    Console.WriteLine("[L]ist all client");
    Console.WriteLine("[Q]uit");
}

void DisplayEditMenu()
{
    Console.WriteLine("\n===Edit Menu===");
    Console.WriteLine("[F]irst Name");
    Console.WriteLine("[L]ast Name");
    Console.WriteLine("[H]eight");
    Console.WriteLine("[W]eight");
    Console.WriteLine("[R]eturn to Main Menu");
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

Client FindClientInList(List<Client> listOfClients)
{
    string myString = Prompt($"Enter Partial Client First Name: ").ToLower().Trim();
    foreach(Client client in listOfClients)
    {
        if(client.FirstName.ToLower().Contains(myString))
            return client;
    }
    Console.WriteLine($"No Clients Match");
    return null;
}

void RemoveClientFromList(Client myClient, List<Client> listOfClients)
{
    if(myClient == null)
        throw new Exception($"No Client provided to remove from list");
    listOfClients.Remove(myClient);
    Console.WriteLine($"Client Removed");
}

void ListAllClient(List<Client> listOfClients)
{
    foreach (Client client in listOfClients)
        ShowClientInfo(client);
}

void LoadFileValuesToMemory(List<Client> listOfClients)
{
    while (true)
    {
        try
        {
            //string fileName = Prompt("Enter file name including .csv or .txt: ");
            string fileName = "regin.csv";
            string filePath = $"./data/{fileName}";
            if (!File.Exists(filePath))
                throw new Exception($"The file {fileName} does not exist.");
            string[] csvFileInput = File.ReadAllLines(filePath);
            for (int i = 0; i < csvFileInput.Length; i++)
            {
                //Console.WriteLine($"lineIndex: {i}; line: {csvFileInput[i]}");
                string[] items = csvFileInput[i].Split(',');
                for (int j = 0; j < items.Length; j++)
                {
                    Console.WriteLine($"itemIndex: {j}; item: {items[j]}");
                }
                Client myClient = new(items[0], items[1], double.Parse(items[2]), double.Parse(items[3]));
                listOfClients.Add(myClient);
            }
            Console.WriteLine($"Load complete. {fileName} has {listOfClients.Count} data entries");
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

void SaveMemoryValuesToFile(List<Client> listOfClients)
{
	//string fileName = Prompt("Enter file name including .csv or .txt: ");
	string fileName = "regout.csv";
	string filePath = $"./data/{fileName}";
	string[] csvLines = new string[listOfClients.Count];
	for (int i = 0; i < listOfClients.Count; i++)
	{
		csvLines[i] = listOfClients[i].ToString();
	}
	File.WriteAllLines(filePath, csvLines);
	Console.WriteLine($"Save complete. {fileName} has {listOfClients.Count} entries.");
}