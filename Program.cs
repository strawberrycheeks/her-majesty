using HerMajesty;

var hall = new Hall();

// TODO: replace with relative path
const string Path = "E:/Courses/7-semester/c-sharp/HerMajesty/res/result.txt";

using (StreamWriter writer = new StreamWriter(Path, false))
{
    for (int i = 0; i < Hall.ContendersCount; i++)
    {
        writer.WriteLine($"{hall.ContenderList[i].Score} {hall.ContenderList[i].Name}");
    }
}