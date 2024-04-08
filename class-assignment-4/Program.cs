using Clients;


bool loopAgain = true;
while (loopAgain)
{
    try
    {
        DisplayMainMenu();
        string mainMenuChoice = Prompt("\nEnter a Main Menu Choice: ").ToUpper();
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