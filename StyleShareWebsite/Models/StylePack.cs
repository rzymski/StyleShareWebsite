using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StyleShareWebsite.Models {
    
    public class StylePack {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public List<Style> Styles { get; set; } = new List<Style>();
        public virtual ICollection<StyleStylePack> StyleStylePacks { get; set; }
        public StylePack() 
        {
            StyleStylePacks = new HashSet<StyleStylePack>();
        }
    }
}
