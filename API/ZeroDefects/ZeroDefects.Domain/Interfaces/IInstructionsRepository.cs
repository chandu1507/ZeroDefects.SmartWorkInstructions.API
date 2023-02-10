using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Entities;

namespace ZeroDefects.Domain.Interfaces
{
    public interface IInstructionsRepository
    {
        Task<Instructions> GetInstructionAsync(string id);
        Task<IEnumerable<Instructions>> GetAllInstructionsAsync();
        Task AddInstructionAsync(Instructions instructions);
        Task<string?> DeleteInstructionAsync(string id);
        Task<Instructions?> UpdateInstructionAsync(Instructions instructions);
    }
}
