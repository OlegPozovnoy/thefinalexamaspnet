using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VbFinal.Models
{
    public class IDataVbPlayer : IMockVbPlayer
    {
        private DbModel db = new DbModel();

        IQueryable<VbPlayer> IMockVbPlayer.VbPlayers { get { return db.VbPlayers; } }

        void IMockVbPlayer.Delete(VbPlayer vbPlayer)
        {
            throw new NotImplementedException();
        }

        VbPlayer IMockVbPlayer.Save(VbPlayer vbPlayer)
        {
            throw new NotImplementedException();
        }
    }
}