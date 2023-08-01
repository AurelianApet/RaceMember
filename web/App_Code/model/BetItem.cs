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
    /// Summary description for BetItem
    /// </summary>
    public class BetItem
    {
        private long _id = 0;
        public long ID
        {
            get { return _id; }
        }

        private long _gameid = 0;
        public long GameID
        {
            get { return _gameid; }
        }

        private long _gamedetailid = 0;
        public long GameDetailID
        {
            get { return _gamedetailid; }
        }

        private int _betkind = 0;
        public int BetKind
        {
            get { return _betkind; }
        }

        private int _bettype = 0;
        public int BetType
        {
            get { return _bettype; }
        }

        private int _target = 0;
        public int Target
        {
            get { return _target; }
        }

        private long _betmoney = 0;
        public long BetMoney
        {
            get { return _betmoney; }
        }

        private double _betratio = 0;
        public double BetRatio
        {
            get { return _betratio; }
        }

        private int _moneytype = 0;
        public int MoneyType
        {
            get { return _moneytype; }
        }

        public BetItem(
            long lID,
            long lGameID,
            long lGameDetailID,
            int iBetKind,
            int iBetType,
            int iTarget,
            long lBetMoney,
            double fBetRatio,
            int iMoneyType
            )
        {
            _id = lID;
            _gameid = lGameID;
            _gamedetailid = lGameDetailID;
            _betkind = iBetKind;
            _bettype = iBetType;
            _target = iTarget;
            _betmoney = lBetMoney;
            _betratio = fBetRatio;
            _moneytype = iMoneyType;
        }
    }
}