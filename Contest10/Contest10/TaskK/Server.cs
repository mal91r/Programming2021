using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

internal class Server
{
    private static Dictionary<string, DateTime> loginSuccess;
    private static Dictionary<string, DateTime> loginFail;
    static Server()
    {
        loginSuccess = new Dictionary<string, DateTime>();
        loginFail = new Dictionary<string, DateTime>();
    }

    public static void ProcessAuthorization(string requestsPath, string requestsResultsPath)
    {

        var info = new CultureInfo("ru-RU");


        using (var sr = new StreamReader(requestsPath))
        {

            using (var sw = new StreamWriter(requestsResultsPath))
            {
                while (sr.Peek() != -1)
                {
                    string s = sr.ReadLine();
                    if(s != null && s != "")
                    {
                        var requestInfo = s.Split(' ');
                        if (requestInfo[0] == "SI")
                        {
                            LogIn(requestInfo[1], requestInfo[2], DateTime.Parse(requestInfo[3]+" " + requestInfo[4], info), sw);
                        }
                        if (requestInfo[0] == "SO")
                        {
                            LogOut(requestInfo[1], sw);
                        }
                    }
                }
            }
        }
    }

    private static void LogIn(string username, string password, DateTime time, StreamWriter sw)
    {
        if (!UserDb.Users.ContainsKey(username))
        {
            sw.WriteLine($"{username}> no user with such login");
        }
        else
        {   
            if (loginSuccess.ContainsKey(username) && time - loginSuccess[username] < new TimeSpan(24, 0, 0))
            {
                sw.WriteLine($"{username}> account blocked due suspicious login attempt");
            }
            else if(password == UserDb.Users[username])
            {

                loginSuccess.Add(username, time);
                sw.WriteLine($"{username}> sign in successful");
            }
            else
            {
                sw.WriteLine($"{username}> incorrect password");
                LogInFail(username, time, sw);
            }  

        }
    }

    private static void LogInFail(string username, DateTime time, StreamWriter sw)
    {
        if (loginFail.ContainsKey(username) && time - loginFail[username] < new TimeSpan(1, 0, 0))
        {
            loginFail[username] = time;
            sw.WriteLine($"{username}> account blocked due suspicious login attempt");
        }
        else
        {
            loginFail.Add(username, time);
        }
    }
    private static void LogOut(string username, StreamWriter sw)
    {
        loginSuccess.Remove(username);
        sw.WriteLine($"{username}> sign out successful");
        
    }
}