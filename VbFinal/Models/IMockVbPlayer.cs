using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VbFinal.Models
{
    public interface IMockVbPlayer
    {
        IQueryable<VbPlayer> VbPlayers { get; }
        VbPlayer Save(VbPlayer vbPlayer);
        void Delete(VbPlayer vbPlayer);
        void Dispose();
    }
}
