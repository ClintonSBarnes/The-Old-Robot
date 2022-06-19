Robot bobby = new Robot();
string? commandEntry;




for (int i = 0; i < bobby.Commands.Length; i++)
{
    Console.WriteLine("Enter command: (O)n, of(F), (N)orth, (S)outh, (E)ast, or (W)est.");
    commandEntry = Console.ReadLine();

    IRobotCommand newCommand = commandEntry switch
    {
        "O" => new OnCommand(),
        "F" => new OffCommand(),
        "N" => new NorthCommand(),
        "S" => new SouthCommand(),
        "E" => new EastCommand(),
        "W" => new WestCommand(),

    };
    bobby.Commands[i] = newCommand;
}
bobby.Run();
Console.ReadKey();



public class Robot 
{
    public int x { get; set; }
    public int y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get;} = new IRobotCommand?[3];

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