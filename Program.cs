using IntsurfingTest.Models;

var repository = new UsersPostsRepository();
await DisplayMainMenuAsync();

async Task DisplayMainMenuAsync()
{
    Console.WriteLine("Select an action:");
    Console.WriteLine("a - Display all users");
    Console.WriteLine("c - Display users by city");
    Console.WriteLine("t - Display top-5 posts users");
    Console.WriteLine("p - Display users by phone");
    Console.WriteLine("m - Display users by email");
    Console.WriteLine("w - Display users by website");
    Console.WriteLine("e - Exit");
    Console.WriteLine("");
    Console.WriteLine("Enter the desired letter: ");
    string letter = Console.ReadLine();

    switch (letter.ToLower())
    {
        case "a":
            await DisplayAllUsersAsync();
            break;
        case "c":
            await DisplayUsersByCityAsync();
            break;
        case "t":
            await DisplayTopPostsUsersAsync();
            break;
        case "p":
            await DisplayUsersByPartOfPhoneAsync();
            break;
        case "m":
            await DisplayUsersByPartOfEmailAsync();
            break;
        case "w":
            await DisplayUsersByPartOfWebsiteAsync();
            break;
        case "e":
            Exit();
            break;
        default:
            Console.Clear();
            Console.WriteLine("UNKNOWN ACTION");
            Console.WriteLine("");
            await DisplayMainMenuAsync();
            break;
    }
}

async Task BackToMainMenuAsync()
{
    Console.WriteLine("");
    Console.WriteLine(@"Enter letter ""b"" to return");
    string letter = Console.ReadLine();
    
    if (letter == "b")
    {
        Console.Clear();
        await DisplayMainMenuAsync();
    } 
    else
    {
        await BackToMainMenuAsync();
    }
}

async Task DisplayAllUsersAsync()
{
    Console.Clear();
    await repository.GetAllUsersPostsAsync();
    await BackToMainMenuAsync();
}

async Task DisplayUsersByCityAsync()
{
    Console.Clear();
    Console.WriteLine(@"Enter start letter of City");
    string letter = Console.ReadLine();
    await repository.GetUsersByCityAsync(letter);
    await BackToMainMenuAsync();
}

async Task DisplayUsersByPartOfPhoneAsync()
{
    Console.Clear();
    Console.WriteLine(@"Enter part of phone");
    string phone = Console.ReadLine();
    await repository.GetUsersByPartOfPhoneAsync(phone);
    await BackToMainMenuAsync();
}

async Task DisplayUsersByPartOfEmailAsync()
{
    Console.Clear();
    Console.WriteLine(@"Enter part of email");
    string email = Console.ReadLine();
    await repository.GetUsersByPartOfEmailAsync(email);
    await BackToMainMenuAsync();
}

async Task DisplayUsersByPartOfWebsiteAsync()
{
    Console.Clear();
    Console.WriteLine(@"Enter part of website");
    string website = Console.ReadLine();
    await repository.GetUsersByPartOfWebsiteAsync(website);
    await BackToMainMenuAsync();
}

async Task DisplayTopPostsUsersAsync()
{
    Console.Clear();
    await repository.GetTopPostsUsersAsync();
    await BackToMainMenuAsync();
}

void Exit()
{
    Environment.Exit(0);
}