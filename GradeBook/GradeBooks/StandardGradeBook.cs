using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeight) : base(name, isWeight)
        {
            Type = GradeBookType.Standard;
            Name = name;
            isWeighted = isWeight;

        }
    }
}
