using Notes.UI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Input;

namespace Notes.UI.Domain.Models
{
    public class LinkModel
    {
        public LinkModel(ELinkType type, string url) : this(type, url, null)
        {
        }

        public LinkModel(ELinkType type, string url, string label = null)
        {
            Label = label ?? type.ToString();
            Url = url;
            Type = type;
        }

        public string Label { get; }

        public string Url { get; }

        public ELinkType Type { get; }

        public ICommand Open { get; }

        private void Execute(object o)
        {
            System.Diagnostics.Process.Start(Url);
        }

        public static LinkModel WindowLink<T>()
        {
            return WindowLink<T>(null);
        }

        public static LinkModel WindowLink<T>(string label)
        {
            return WindowLink<T>(label, null);
        }

        public static LinkModel WindowLink<T>(string label, string nameSpace)
        {
            var ext = typeof(UserControl).IsAssignableFrom(typeof(T))
                ? "xaml"
                : "cs";


            return new LinkModel(
                ELinkType.WindowSource,
                null,
                label ?? typeof(T).Name);
        }
    }
}
