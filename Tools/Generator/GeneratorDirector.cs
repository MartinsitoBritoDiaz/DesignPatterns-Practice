using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Builder;

namespace Tools.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator   _builderGenerator;

        public GeneratorDirector(IBuilderGenerator builderGenerator)
        {
            SetBuilder(builderGenerator);
        }

        public void SetBuilder(IBuilderGenerator builderGenerator) => _builderGenerator = builderGenerator;
    
        public void CreateSimpleJson(List<string> Content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(Content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipes(List<string> Content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(Content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Pipes);
            _builderGenerator.SetCharacter(TypeCharacter.Uppercase);
        }
    }
}
