using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Ronaldo.model
{

    /// <summary>
    /// Summary description for Lottery
    /// </summary>
    public class Lottery
    {
        private int _id = 0;

        public int ID
        {
            get { return _id; }
        }

        private string _nick = null;
        public string Nick
        {
            get { return _nick; }
        }

        private string _name = null;

        public string Name
        {
            get { return _name; }
        }

        private string _desc = null;
        public string Description
        {
            get { return _desc; }
        }

        private bool _isPlaying = false;
        public bool Playing
        {
            get { return _isPlaying; }
        }

        public Lottery()
        {
            _id = 0;
            _nick = null;
            _name = null;
            _desc = null;
            _isPlaying = false;
        }

        public Lottery(int nID, string strLotteryNick, string strLotteryName, string strLotteryDesc, bool bIsPlaying)
        {
            _id = nID;
            _nick = strLotteryNick;
            _name = strLotteryName;
            _desc = strLotteryDesc;
            _isPlaying = bIsPlaying;
        }
    }
}
