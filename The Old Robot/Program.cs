Robot bobby = new Robot();
string? commandEntry;
int commandCount;

Console.WriteLine("How many commands will you be entering? ");
commandCount = Convert.ToInt16(Console.ReadLine());

for (int i = 0; i < commandCount; i++)
{
    Console.WriteLine("Enter command: (O)n, of(F), (N)orth, (S)outh, (E)ast, or (W)est.");
    commandEntry = Console.ReadLine().ToUpper();

    IRobotCommand newCommand = commandEntry switch
    {
        "O" => new OnCommand(),
        "F" => new OffCommand(),
        "N" => new NorthCommand(),
        "S" => new SouthCommand(),
        "E" => new EastCommand(),
        "W" => new WestCommand(),

    };
    bobby.Commands.Add(newCommand);
}
bobby.Run();
Console.ReadKey();



public class Robot 
{
    public int x { get; set; }
    public int y { get; set; }
    public bool IsPowered { get; set; }
    public List<RobotCommand?> Commands { get; } = new List<RobotCommand?>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{x}, {y} {IsPowered}]");
        }
    }


}


public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;

    }

}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;

    }

}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.y += 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.y -= 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.x -= 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered == true)
        {
            robot.x += 1;
        }
        else Console.WriteLine("The robot has no power.");
    }

}

public interface IRobotCommand
{
    void Run(Robot robot);

}