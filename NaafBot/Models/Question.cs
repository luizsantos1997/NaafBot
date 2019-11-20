using System;
using System.Collections.Generic;

namespace NaafBot.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public DateTime DtCriacao { get; set; }
        public string TxQuestion { get; set; }
    }
}
