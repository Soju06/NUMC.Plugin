using NUMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AppCommand
{
    public static class AppCommands
    {
        public static AppCommand[] GetAppCommands(ResourceManager resource = null)
        {
            var r = resource ?? GetResource();
            var acs = new List<AppCommand>();
            var es = (APPCOMMAND[])Enum.GetValues(typeof(APPCOMMAND));
            for (int i = 0; i < es.Length; i++) {
                var e = es[i]; var n = r.GetString(e.ToString());
                if (n != null) acs.Add(new AppCommand() { Command = e, Text = n });
            } return acs.ToArray();
        }

        public static string APPCOMMANDToString(APPCOMMAND appCommand, ResourceManager resource = null)
        {
            var r = resource ?? GetResource();
            return r.GetString(appCommand.ToString());
        }

        public static string AppCommandContextLocalizing(ResourceManager resource = null) =>
            (resource ?? GetResource()).GetString("Script_Context");

        public static string AppCommandAddMenuTextLocalizing(ResourceManager resource = null) =>
            (resource ?? GetResource()).GetString("Menu_Add_Text");


        public static string AppCommandEditMenuTextLocalizing(ResourceManager resource = null) =>
            (resource ?? GetResource()).GetString("Menu_Edit_Text");

        public static ResourceManager GetResource()
        {
            var lng = Service.GetService()?
                .GetScript()?.GetObject()?.Language?.ToLower();
            var l = lng != "ko-kr" ? "en-us" : lng;
            return new ResourceManager($"AppCommand.{l}_c", typeof(AppCommands).Assembly);
        }

        public static APPCOMMAND? ToAppCommnad(string data)
        {
            if (data == null || !Enum.TryParse<APPCOMMAND>(
                data, out var command)) return null;
            return command;
        }
    }

    public class AppCommand
    {
        public APPCOMMAND Command { get; set; }
        public string Text { get; set; }
        public string GetData() => Command.ToString();
    }
}
