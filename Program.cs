using HerMajesty;

Hall hall = new Hall();

for (int i = 0; i < Hall.ContendersCount; i++)
{
    Console.WriteLine(hall.ContenderList[i].Score + " " + hall.ContenderList[i].Name);
}