﻿using System;
using System.Collections.Generic;
using System.Text;
using MultiLineCharOutput.Release;

namespace MultiLineCharOutput.Payment {
    
    public class EftPayment : BasePayment {

        protected override string SetRecvBankPrimaryIdType(AP ap) {
            return "ABA";
        }
        protected override string SetRcrsAccountNum(AP ap) {
            return ap.RcrsAccountNum;
        }
        protected override string SetTransactionNumber(AP ap) {
            var sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyyMMdd"));
            var curLen = sb.ToString().Length;
            sb.Append(_transNbr.ToFixedStringRight(15 - curLen, '0'));
            return sb.ToString().ToFixedString(30);
        }
        public EftPayment(AP ap) : base(ap) {
            this.PaymentMethod = PaymentMethodEft;
            this.PaymentAmount = ap.EftAmt;
            this.ValueDate = DateTime.Parse(ap.EffectiveDate);
            this.RecvBankPrimaryIdType = "ABA";
            this.RecvBankPrimaryId = ap.RcrsTransitRoute.ToFixedStringRight(9, '0');
        }
    }
}
