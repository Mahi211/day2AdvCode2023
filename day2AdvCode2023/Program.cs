
int runningTotal = 0;
int powerTotal = 0;
const int maxRed = 12;
const int maxGreen = 13;
const int maxBlue = 14;
string filePath = "input.txt";
string[] lines = File.ReadAllLines(filePath);


foreach (var line in lines)
{
    var gameInfo = line.Split(':');   // splits into game info and gameid one side is "game 1" other side is the turns "3 blue ..."
    int gameID = int.Parse(gameInfo[0].Split(' ')[1]); // gets game id just one number output "2" "3"
    var rounds = gameInfo[1].Split(";", StringSplitOptions.TrimEntries);   // splits each game into separate round "3 blue, 4 red" is one round
    bool isValidGame = true;
    bool isValidCube = true;
   
    List<int> blues = new();
    List<int> greens = new();
    List<int> reds = new();

    

    foreach (var round in rounds)
    {


        var colorInfos = round.Split(",", StringSplitOptions.TrimEntries);
       /* if (round.Contains("green") && round.Contains("blue") && round.Contains("red"))
        {
            isValidCube = true;
        }
       Jag va ute o cykla här läste frågan fel
       */

            
        foreach (var color in colorInfos)
        {
            var colorInfo = color.Split(" ");
            var colorCount = int.Parse(colorInfo[0]);
            var colorName = colorInfo[1];
            
            

            if (colorName == "blue")
            {
                blues.Add(colorCount);
            }

           else if (colorName == "red")
                {
                reds.Add(colorCount);
                }
           else if (colorName == "green")
            {
                greens.Add(colorCount);
            }
            if ((colorName == "blue" && colorCount > maxBlue) || (colorName == "red" && colorCount > maxRed) || (colorName == "green" && colorCount > maxGreen))
            {
                isValidGame = false;

            }   
        }
        
        
       
    }
    // det var bara att ändra till Max egentligen på sättet frågan var ställd
    Cube cubey = new Cube();
    cubey.Width = reds.Max();
    cubey.Length = greens.Max();
    cubey.Height = blues.Max();
    var sum = cubey.Width * cubey.Height * cubey.Length;
    powerTotal += sum;

    if (isValidGame)
    {
        runningTotal += gameID;
    }
}

// Första Svaret här under v
Console.WriteLine("Answer to Part 1 is: " + runningTotal);

// andra svaret här under v

Console.WriteLine("Answer to Part 2 is: " + powerTotal);

 public class Cube
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int Length { get; set; }
}