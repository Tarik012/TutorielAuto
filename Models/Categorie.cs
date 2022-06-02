using System;
using System.Collections.Generic;

namespace TutorielAuto.TutorielAuto.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Tutoriels = new HashSet<Tutoriel>();
        }

        public int Id { get; set; }
        public string Label { get; set; } = null!;

        public virtual ICollection<Tutoriel> Tutoriels { get; set; }
    }
}
