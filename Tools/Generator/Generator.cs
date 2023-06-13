using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools.Builder;

namespace Tools.Generator
{
    public class Generator
    {
        public List<string> Content { get; set; }
        public string Path { get; set; }
        public TypeFormat Format { get; set; }
        public TypeCharacter Character { get; set; }
        public void Save()
        {
            string result = "";
            result = Format == TypeFormat.Json ? GetJson() : GetPipe();
            _ = Character == TypeCharacter.Uppercase ? result.ToUpper() : result.ToLower();

            File.WriteAllText(Path, result);
        }

        private string GetJson() => JsonSerializer.Serialize(Content);
        private string GetPipe() => Content.Aggregate((accum, current) => accum + '|' + current);
    }
}
