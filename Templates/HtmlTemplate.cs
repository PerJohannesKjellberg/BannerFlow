﻿using System;
using System.IO;

namespace BannerFlow.Templates
{
    public class HtmlTemplate
    {
        private string _html;

        public HtmlTemplate(string templatePath)
        {
            using (var reader = new StreamReader(templatePath))
                _html = reader.ReadToEnd();
        }

        public string Render(object values)
        {
            string output = _html;
            foreach (var p in values.GetType().GetProperties())
                output = output.Replace("[" + p.Name + "]", (p.GetValue(values, null) as string) ?? string.Empty);
            return output;
        }
    }
}