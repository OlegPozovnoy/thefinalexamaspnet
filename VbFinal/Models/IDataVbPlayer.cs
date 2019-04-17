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
            db.VbPlayers.Remove(vbPlayer);
            db.SaveChanges();
        }

        VbPlayer IMockVbPlayer.Save(VbPlayer vbPlayer)
        {
            if (vbPlayer.VbPlayerId == 0)
            {
                db.VbPlayers.Add(vbPlayer);
            }
            else
            {
                db.Entry(vbPlayer).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return vbPlayer;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}