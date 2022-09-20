using HerMajesty;
using HerMajesty.util;

var hall = new Hall();

using (StreamWriter writer = new StreamWriter(Constants.ResultPath, false))
{
    for (int i = 0; i < Constants.ContendersCount; i++)
    {
        writer.WriteLine($"{hall.ContenderList[i].Score} {hall.ContenderList[i].Name}");
    }
}