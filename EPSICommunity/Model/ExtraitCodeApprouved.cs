using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Model
{
    public class ExtraitCodeApprouved
    {
        public int Id;
        public int IdExtraitCode;
        public List<int> ListApprouver;

        public ExtraitCodeApprouved(int id, int idExtraitCode, List<int> listApprouver)
        {
            Id = id;
            IdExtraitCode = idExtraitCode;
            ListApprouver = listApprouver;
        }
    }
}
