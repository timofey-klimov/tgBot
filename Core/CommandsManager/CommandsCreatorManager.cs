using Core.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CommandsManager
{
    public class CommandsCreatorManager
    {
        private readonly IEnumerable<CommandCreator> _creators;

        public CommandsCreatorManager(IEnumerable<CommandCreator> commandCreators)
        {
            if (!commandCreators.Any())
                throw new ArgumentException(nameof(commandCreators));
            _creators = commandCreators;
        }
        public IEnumerable<CommandCreator> GetCreators() => _creators;
    }
}
