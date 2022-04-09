using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.CSharp;
using System.Drawing;
using System.Windows.Controls;

namespace Tester
{
    
    public class Tester : Application
    {
        public int open;

        LoadPrice();
        /*DateTime date = candles[candles.Count - 1].TimeStart;
        var dt = date.ToString("yyyyMMdd");
                if (Go.ContainsKey(dt))
                {
                    TekGo = Go[dt];
                }*/
    }
    private void LoadPrice()
    {
        var file = "Si.txt";
        var path = $"{Environment.CurrentDirectory}\\Data\\GO\\{file}";

        if (!File.Exists(path)) { return; }

        var line = "";
        try
        {
            var reader = new StreamReader(path);
            line = reader.ReadLine();

            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    var str = line.Split(',');

                    if (str.Length > 7 && !string.IsNullOrEmpty(str[7]))
                    {
                        var date = str[2];
                        var Open = Convert.ToDecimal(str[3]);

                        if (Open > 0)
                        {
                            open[date] = Open;
                        }
                    }
                }
            }
            reader.Close();
        }
        catch (Exception)
        {

        }
    }
}
