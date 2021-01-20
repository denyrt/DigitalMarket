using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalMarket.Models.Common
{
    public class PageFilter
    {
        [Range(0, int.MaxValue)]
        public int Page { get; set; } = 0;

        [Range(1, 100)]
        public int CountInPage { get; set; } = 10;
                
        public int TakeValue() => CountInPage;
        
        public int SkipValue() => Page * CountInPage;
    }
}