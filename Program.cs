using System;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    string selectedKey = "A";
    List<string> toDos = new List<string>();
    do
    {
      Console.Clear();
      titlePrinter();
      selectedKey = Console.ReadLine() ?? "0";

      switch (selectedKey.ToUpper())
      {
        case "A":
          Console.Clear();
          string newToDo = getNewToDo();
          toDos.Add(newToDo);
          break;

        case "S":
          Console.Clear();
          listAllToDos(toDos);
          Console.WriteLine("Press any key to continue");
          Console.ReadKey();
          break;

        case "R":
          Console.Clear();
          listAllToDos(toDos);

          Console.WriteLine("What's the number of the ToDo you wish to remove?");
          try
          {
            string choice = Console.ReadLine() ?? "NULL";
            int indexToRemove = int.Parse(choice);
            toDos.RemoveAt(indexToRemove - 1);
          }
          catch (Exception ex)
          {
            Console.WriteLine("Next time, pay attention to what you're typing, bitch", ex);
          }
          break;

        case "E":
          Console.Clear();
          Console.WriteLine("See you next time!");
          break;

        default:
          Console.Clear();
          Console.WriteLine("Invalid choice!");
          break;
      }

    } while (selectedKey.ToUpper() != "E");

  }

  static void titlePrinter ()
  {
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all ToDo\"s");
    Console.WriteLine("[A]dd a ToDo\"s");
    Console.WriteLine("[R]emove a ToDo\"s");
    Console.WriteLine("[E]xit");
  }

  static void listAllToDos (List<string> toDos)
  {
    if (toDos.Count == 0)
    {
      Console.WriteLine("Nothing to see here!");

      return;
    }
    int toDoCounter = 0;
    Console.WriteLine("ALL YOUR TO-DOS");
    foreach (string toDo in toDos)
    {
      string message = $"N.{toDoCounter + 1} | {toDo}";
      Console.WriteLine(message);

      toDoCounter += 1;
    }
  }

  static string getNewToDo ()
  {
    string confirmed = "N";
    string newToDo;

    Console.WriteLine("ADD | TO-DO MENU");
    do
    {
    Console.WriteLine("What To-Do you wish to add?");
    newToDo = Console.ReadLine() ?? "Typo";

    if (newToDo.Length == 0)
    {
      Console.WriteLine("ToDo cannot be empty");
      Console.Clear();
      continue;
    }

    Console.WriteLine($"Do you wish insert new ToDo: {newToDo}");

    Console.WriteLine("Confirm? [Y] Yes | [N] No");
    confirmed = Console.ReadLine() ?? "N";
    } while (confirmed.ToUpper() != "Y");

    return newToDo;
  }
}
