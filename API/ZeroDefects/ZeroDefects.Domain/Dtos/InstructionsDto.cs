using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroDefects.Domain.Dtos
{

    public class InstructionsDto 
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
        public bool Isactive { get; set; }
        public string CreatedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }
    }
            


            
    
}
