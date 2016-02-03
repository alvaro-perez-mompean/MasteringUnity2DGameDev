using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NavigationManager {
    public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
    {
        { "World", "The big bad world" },
        { "Cave", "The deep dark cave" },
        { "Town", "Main town" }
    };

    public static string GetRouteInfo(string destination)
    {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
    }

    public static bool CanNavigate(string destination)
    {
        return true;
    }

    public static bool NavigateTo(string destination)
    {
        if (CanNavigate(destination))
        {
            SceneManager.LoadScene(destination);
            return true;
        }
        else
        {
            return false;
        }
    }
}
