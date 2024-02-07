




using System;

class VirtualPet
{
    private const int MaxStatValue = 10;
    private const int MinStatValue = 1;

    private string name;
    private int hunger;
    private int happiness;
    private int health;

    public VirtualPet(string petName)
    {
        name = petName;
        hunger = MaxStatValue / 2;
        happiness = MaxStatValue / 2;
        health = MaxStatValue / 2;
    }

    public void DisplayWelcomeMessage(string petType)
    {

        Console.WriteLine($"\nYou have a {petType}. what would you like to name your {name}.");
        Console.WriteLine($"\nWelcome,{name}! Let's take good care of {petType}");
    }

    public void DisplayStats(string petType)
    {
        Console.WriteLine($"\n {petType} Stats:");
        Console.WriteLine($"Hunger: {hunger}/10");
        Console.WriteLine($"Happiness: {happiness}/10");
        Console.WriteLine($"Health: {health}/10");
    }

    public void Feed()
    {
        //Feeding decreases hunger by 10 Feeding increases happiness


        hunger -= 2;
        happiness++;
        Console.WriteLine($"\nYou feed {name}.His Hunger decreases and happiness improves slightly.");
        PassTime();
    }

    public void Play()
    {
        if (hunger <= 3)
        {
            Console.WriteLine($"\nyou played with {name}. is too hungry to play.");
        }
        else
        {

            happiness += 2; // Playing increases happiness by 2
            hunger++; // Playing increases hunger
            Console.WriteLine($"\n{name} plays happily.");
            PassTime();
        }
    }

    public void Rest()
    {
        health += 2; // Resting increases health by 2
        happiness--; // Resting decreases happiness
        Console.WriteLine($"\n{name} takes a rest. His Health improves but happiness decreases.");
        PassTime();
    }

    private void PassTime()
    {
        hunger++;
        happiness--;
        if (hunger > MaxStatValue) hunger = MaxStatValue;
        if (happiness < MinStatValue) happiness = MinStatValue;
        if (health < MinStatValue) health = MinStatValue;
        if (hunger <= 3) health--;
    }

    public void CheckStatus()
    {
        if (hunger <= 3)
        {
            Console.WriteLine($"\n{name} is very hungry! Please feed {name}.");
        }
        if (happiness <= 3)
        {
            Console.WriteLine($"\n{name} is very unhappy! Play with {name} to increase happiness.");
        }
        if (health <= 3)
        {
            Console.WriteLine($"\n{name}'s health is deteriorating! Make sure {name} rests.");
        }
    }
}

class Program
{
    static void Main()
    {


        Console.WriteLine("\nPlease choose a type of pet:");
        Console.WriteLine("1. Dog");
        Console.WriteLine("2. Cat");
        Console.WriteLine("3. Rabbit");
        Console.Write("\nEnter your choice: \n");
        string petType = Console.ReadLine();

        Console.Write("\nEnter your pet's name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petName);

        pet.DisplayWelcomeMessage(GetPetType(petType));

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1.Display Stats");
            Console.WriteLine("2. Feed");
            Console.WriteLine("3. Play");
            Console.WriteLine("4. Rest");
            Console.WriteLine("5. Quit");

            Console.Write("\nEnter your choice: \n");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pet.DisplayStats(GetPetType(petType));
                    pet.CheckStatus();
                    break;
                case "2":
                    pet.Feed();
                    break;
                case "3":
                    pet.Play();
                    break;
                case "4":
                    pet.Rest();
                    break;
                case "5":
                    Console.WriteLine($"Thank you play for with {petName}. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }

    static string GetPetType(string choice)
    {
        switch (choice)
        {
            case "1":
                return "Dog";
            case "2":
                return "Cat";
            case "3":
                return "Rabbit";
            default:
                return "Unknown";
        }
    }
}


