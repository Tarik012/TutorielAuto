using System;
using System.Collections.Generic;

namespace TutorielAuto.TutorielAuto.Models
{
    public partial class Tutoriel
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public DateTime Dcc { get; set; }
        public string Contenu { get; set; } = null!;
        public string VideoLink { get; set; } = null!;
        public DateTime Dml { get; set; }
        public int Type { get; set; }
        public int CategorieId { get; set; }

        public virtual Categorie Categorie { get; set; } = null!;
    }
}
