using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Web;

namespace ds.test.impl
{
    public abstract class Row1
    {
        public abstract int Run(int input1);
    }
    public interface IPlugin
    {
        string PluginName { get; }
        string Version { get; }
        System.Drawing.Image Image { get; }
        string Description { get; }
        int Run(int input1, int input2);
    }

    public interface PluginFactory
    {
        int PluginsCount { get; }
        string[] GetPluginsNames { get; }
        IPlugin GetPlugin(string pluginName);
    }

    public class Plugins : PluginFactory
    {
        int _pluginsCount = 3;
        int PluginFactory.PluginsCount { get { return _pluginsCount; } }
        string[] _getPluginsNames = { "Row", "Sum", "Subtraction" };
        string[] PluginFactory.GetPluginsNames { get { return _getPluginsNames; } }


        IPlugin PluginFactory.GetPlugin(string pluginName)
        {
            switch (pluginName)
            {
                case "Row":
                    return new Row();
                case "Sum":
                    return new Sum();
                case "Subtraction":
                    return new Subtraction();
                default:
                    break;
            }
            return null;

        }


    }

    public class Row : Row1, IPlugin
    {
        string _pluginName = "Row";
        string IPlugin.PluginName { get { return _pluginName; } }
        string _version = "0.0.1";
        string IPlugin.Version { get { return _version; } }

        System.Drawing.Image IPlugin.Image
        {
            get
            {
                var request = WebRequest.Create("https://w-dog.ru/wallpapers/5/18/289291145046987/evropejskaya-koshka-dikij-kot-morda-vzglyad.jpg");
                {
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            return System.Drawing.Image.FromStream(stream);
                        }
                    }

                }
            }
        }
        string _description = "Use this to exponentiate";
        string IPlugin.Description { get { return _description; } }

        override public int Run(int input1)
        {
            try
            {
                return input1 * input1;
            }
            catch
            {
                return 0;
            }
        }


        int IPlugin.Run(int input1, int input2)
        {
            return (int)Math.Pow(input1, input2);
        }


    }
    public class Sum : IPlugin
    {
        string _pluginName = "Sum";
        string IPlugin.PluginName { get { return _pluginName; } }
        string _version = "0.0.1";
        string IPlugin.Version { get { return _version; } }
        System.Drawing.Image IPlugin.Image
        {
            get
            {
                var request = WebRequest.Create("https://proprikol.ru/wp-content/uploads/2020/12/kartinki-ryzhih-kotov-1.jpg");
                {
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            return System.Drawing.Image.FromStream(stream);
                        }
                    }

                }
            }
        }
        string _description = "Use this to sum first and second input numbers";
        string IPlugin.Description { get { return _description; } }
        int IPlugin.Run(int input1, int input2)
        {
            return input1 + input2;
        }


    }
    public class Subtraction : IPlugin
    {
        string _pluginName = "Subtraction";
        string IPlugin.PluginName { get { return _pluginName; } }
        string _version = "0.0.1";
        string IPlugin.Version { get { return _version; } }


        System.Drawing.Image IPlugin.Image
        {
            get
            {
                var request = WebRequest.Create("https://proprikol.ru/wp-content/uploads/2020/08/krasivye-kartinki-kotov-22.jpg");
                {
                    using (var response = request.GetResponse())
                    {
                        using (var stream = response.GetResponseStream())
                        {
                            return System.Drawing.Image.FromStream(stream);
                        }
                    }

                }
            }
        }
        string _description = "Use this to subtract second from first input number";
        string IPlugin.Description { get { return _description; } }
        int IPlugin.Run(int input1, int input2)
        {
            return input1 - input2;
        }


    }


}