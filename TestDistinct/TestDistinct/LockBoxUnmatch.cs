using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDistinct
{
	public class LockBoxUnmatch
	{
		[Key]
		public int CashUnmatchID { get; set; }
		public int RecordCode { get; set; }
		public int BatchNo { get; set; }
		public int TransNo { get; set; }
		public int LockBoxNo { get; set; }
		public string AcctNo { get; set; }
		public DateTime DepositDate { get; set; }
		public string CompNo { get; set; }
		public DateTime BillPer { get; set; }
		public decimal AmountDue { get; set; }
		public string CheckNo { get; set; }
		public decimal CheckAmount { get; set; }
		public decimal BatchTotal { get; set; }
		public int CompID { get; set; }
		public string MultiInd { get; set; }

		public LockBoxUnmatch(int RecordCode_, int BatchNo_, int TransNo_, int LockBoxNo_, string AcctNo_, DateTime DepositDate_, string CompNo_, DateTime BillPer_, decimal AmountDue_, string CheckNo_, decimal CheckAmount_, decimal BatchTotal_, int CompID_, string MultiInd_, int CashUnmatchID_)
		{
			this.RecordCode = RecordCode_;
			this.BatchNo = BatchNo_;
			this.TransNo = TransNo_;
			this.LockBoxNo = LockBoxNo_;
			this.AcctNo = AcctNo_;
			this.DepositDate = DepositDate_;
			this.CompNo = CompNo_;
			this.BillPer = BillPer_;
			this.AmountDue = AmountDue_;
			this.CheckNo = CheckNo_;
			this.CheckAmount = CheckAmount_;
			this.BatchTotal = BatchTotal_;
			this.CompID = CompID_;
			this.MultiInd = MultiInd_;
			this.CashUnmatchID = CashUnmatchID_;
		}
	}
}
