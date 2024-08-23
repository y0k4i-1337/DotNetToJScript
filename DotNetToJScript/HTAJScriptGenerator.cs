//    This file is part of DotNetToJScript - A tool to generate a 
//    JScript which bootstraps an arbitrary v2.NET Assembly and class.
//    Copyright (C) James Forshaw 2017
//
//    DotNetToJScript is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    DotNetToJScript is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with DotNetToJScript.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Linq;
using System.Text;

namespace DotNetToJScript
{
    class HTAJScriptGenerator : IScriptGenerator
    {
        static string GetScriptHeader()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<html>");
            builder.AppendLine("<head>");
            builder.AppendLine("<script language=\"JScript\">");
            return builder.ToString();
        }

        static string GetScriptFooter()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendLine("</script>");
            builder.AppendLine("</head>");
            builder.AppendLine("<body>");
            builder.AppendLine("<script language=\"JScript\">");
            builder.AppendLine("self.close();");
            builder.AppendLine("</script>");
            builder.AppendLine("</body>");
            builder.AppendLine("</html>");
            return builder.ToString();
        }

        public string ScriptName
        {
            get
            {
                return "HTAJScript";
            }
        }

        public bool SupportsScriptlet
        {
            get
            {
                return true;
            }
        }

        public string GenerateScript(byte[] serialized_object, string entry_class_name, string additional_script, RuntimeVersion version, bool enable_debug)
        {
            JScriptGenerator generator = new JScriptGenerator();
            string script = generator.GenerateScript(serialized_object, entry_class_name, additional_script, version, enable_debug);

            return GetScriptHeader() + script + GetScriptFooter();
        }
    }
}
