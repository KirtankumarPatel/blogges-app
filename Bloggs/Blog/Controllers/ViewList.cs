using System;
using System.Collections.Generic;

class ViewList
{
    static void Main()
    {
        List<string> items = new List<string> { "Item 1", "Item 2", "Item 3" };
        ListController controller = new ListController();
        controller.Index(items);
    }
}

class ListController
{
    public void Index(List<string> items)
    {
        ListView view = new ListView();
        view.Render(items);
    }
}

class ListView
{
    public void Render(List<string> items)
    {
        Console.WriteLine("List of Items:");

        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }
    }
}
